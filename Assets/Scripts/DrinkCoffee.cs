﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DrinkCoffee : MonoBehaviour {

	public AudioClip[] drinkingClips;
	public AudioClip[] cupClips;

	private AudioSource audioSource;
	private Animator animator;
	private bool isDrinking = false;

	void Start () {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
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

	        if (!audioSource.isPlaying) {
//	        	audio.clip = drinkingClips[Random.Range(0, drinkingClips.Length)];
//	        	audio.Play();
				audioSource.PlayOneShot(drinkingClips[Random.Range(0, drinkingClips.Length)]);
	        }
		}
		else if (animator.IsInTransition(0) && animator.GetNextAnimatorStateInfo(0).IsName("Paris_Idle")) {
//			AudioSource audio = GetComponent<AudioSource>();
			if (!audioSource.isPlaying) {
				audioSource.PlayOneShot(cupClips[Random.Range(0, cupClips.Length)]);
//	        	audio.clip = cupClips[Random.Range(0, cupClips.Length)];
//	        	audio.Play();
	        }
		}
	}
}
