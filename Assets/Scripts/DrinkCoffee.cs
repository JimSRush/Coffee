using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DrinkCoffee : MonoBehaviour {

	public AudioClip[] drinkingClips;
	public AudioClip[] cupClips;

	private AudioSource audioSource;
	private Animator animator;
	private bool hasStartedDrinking = false;
	private bool isDrinking = false;

	void Start () {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetKeyDown("space") && GameController.IsInputEnabled) {
			isDrinking = true;
			animator.SetBool("IsDrinkingCoffee", isDrinking);
			Debug.Log("Total drunk: " + GameController.totalTimeSpentDrinkingCoffee);
		}
		else if (Input.GetKeyUp("space") || (!GameController.IsInputEnabled && isDrinking)) {
			isDrinking = false;
			animator.SetBool("IsDrinkingCoffee", false);
			Debug.Log("Total drunk: " + GameController.totalTimeSpentDrinkingCoffee);
		}
		if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Paris_Drink_Coffee")) {
			GameController.totalTimeSpentDrinkingCoffee += 1.0f * Time.deltaTime;
			if (hasStartedDrinking == false) hasStartedDrinking = true;

	        if (!audioSource.isPlaying) {
				audioSource.PlayOneShot(drinkingClips[Random.Range(0, drinkingClips.Length)]);
	        }
		}
//		else if (animator.IsInTransition(0) && animator.GetNextAnimatorStateInfo(0).IsName("Paris_Idle")) {
//			if (!audioSource.isPlaying) {
//				audioSource.PlayOneShot(cupClips[Random.Range(0, cupClips.Length)]);
//	        }
//		}
	}

	public bool IsDrinking () {
		return isDrinking;
	}

	public bool HasStartedDrinking () {
		return hasStartedDrinking;
	}
}
