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
			isDrinking = !isDrinking;
			animator.SetBool("IsDrinkingCoffee", isDrinking);
			//play slurp
		}
	}
}
