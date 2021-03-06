﻿using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour, IMetric {

	public float amountToDrink;
	public GameObject player;
	// The time after the fade has finished
	public float initialIdleTimeToTransition = 10.0f;
	// The time to transition after having at least one drink
	public float timeToTransition = 5.0f;

	private GameController gameController;
	private DrinkCoffee coffeeController;
	private Fade fader;
	private float beginningAmount;
	private float currentIdleTime = 0.0f;
	private bool isLeavingScene = false;

	// Metrics
	private float totalTimeIdle = 0.0f;

	// Use this for initialization
	void Start () {
		coffeeController = player.GetComponent<DrinkCoffee>();
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

		beginningAmount = GameController.totalTimeSpentDrinkingCoffee;
		fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<Fade>();
		initialIdleTimeToTransition += fader.FadeTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameController.IsChangingScene()) {
			if (!coffeeController.IsDrinking()) {
				currentIdleTime += Time.deltaTime;
				float idleToExceed = coffeeController.HasStartedDrinking() ? timeToTransition : initialIdleTimeToTransition;
				if (currentIdleTime > idleToExceed) {
					ProceedToNextScene();
				}
			} else {
				totalTimeIdle += currentIdleTime;
				currentIdleTime = 0.0f;

				float amountDrunkThisScene = GameController.totalTimeSpentDrinkingCoffee - beginningAmount;
				if (amountDrunkThisScene >= amountToDrink) {
					ProceedToNextScene ();
				}
			}
		}
	}

	void ProceedToNextScene () {
		// Proceed to next scene
		gameController.StartCoroutine ("changeScene");
		isLeavingScene = true;
		UpdateMetrics();
	}

	public bool IsLeavingScene () {
		return isLeavingScene;
	}

	public void UpdateMetrics () {
		MetricController mc = gameController.MetricController();
		if (coffeeController.HasStartedDrinking()) {
			mc.totalTimeIdle += totalTimeIdle;
		}

		float timeOnThisSceneDrinking = GameController.totalTimeSpentDrinkingCoffee - beginningAmount;
		mc.totalCupsConsumed += timeOnThisSceneDrinking/amountToDrink;
	}
}
