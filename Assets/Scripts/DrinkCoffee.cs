using UnityEngine;
using System.Collections;

public class DrinkCoffee : MonoBehaviour {

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
		if (Input.GetKeyUp("space")) {
			isDrinking = false;
			animator.SetBool("IsDrinkingCoffee", isDrinking);
			Debug.Log("Total drunk: " + GameController.totalTimeSpentDrinkingCoffee);
		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Paris_Drink_Coffee")) {
			GameController.totalTimeSpentDrinkingCoffee += 1.0f * Time.deltaTime;
		}
	}
}
