using UnityEngine;
using System.Collections;

public class DrinkCoffee : MonoBehaviour {

	public AudioClip[] drinkingClips;
	public AudioClip[] cupClips;

	private Animator animator;
	private bool isDrinking = false;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update () {
		if (Input.GetKeyDown("space")) {
			isDrinking = true;
			animator.SetBool("IsDrinkingCoffee", isDrinking);
			Debug.Log("Total drunk: " + GameController.totalTimeSpentDrinkingCoffee);
			//play slurp
		}
		else if (Input.GetKeyUp("space")) {
			isDrinking = false;
			animator.SetBool("IsDrinkingCoffee", isDrinking);
			Debug.Log("Total drunk: " + GameController.totalTimeSpentDrinkingCoffee);
		}
		if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Paris_Drink_Coffee")) {
			GameController.totalTimeSpentDrinkingCoffee += 1.0f * Time.deltaTime;
			AudioSource audio = GetComponent<AudioSource>();
	        if (!audio.isPlaying) {
	        	audio.clip = drinkingClips[Random.Range(0, drinkingClips.Length)];
	        	audio.Play();
	        }
		}
		else if (animator.IsInTransition(0) && animator.GetNextAnimatorStateInfo(0).IsName("Paris_Idle")) {
			AudioSource audio = GetComponent<AudioSource>();
	        if (!audio.isPlaying) {
	        	audio.clip = cupClips[Random.Range(0, cupClips.Length)];
	        	audio.Play();
	        }
		}
	}
}
