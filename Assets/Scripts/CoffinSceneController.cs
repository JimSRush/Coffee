using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class CoffinSceneController : MonoBehaviour {

	public float timeToWait = 8.0f;
	private GameController gameController;
	private float currentIdleTime = 0.0f;
	private bool isLeavingScene = false;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		GameController.IsGameOver = true;
	}
	
	// Update is called once per frame
	void Update () {
		currentIdleTime += Time.deltaTime;
		if (currentIdleTime > timeToWait && !isLeavingScene) {
			ProceedToNextScene();
			isLeavingScene = true;
		}
	}

	void ProceedToNextScene () {
		// Proceed to next scene
		gameController.StartCoroutine ("changeScene");
	}
}
