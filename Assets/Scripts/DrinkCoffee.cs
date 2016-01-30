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
			//play slurp
		}
		if (Input.GetKeyUp("space")) {
			isDrinking = false;
			animator.SetBool("IsDrinkingCoffee", isDrinking);
		}
	}
}
