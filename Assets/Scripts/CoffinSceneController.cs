using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class CoffinSceneController : MonoBehaviour {

	public float timeToWait = 8.0f;
	private GameController gameController;
	private float currentIdleTime = 0.0f;

	// Use this for initialization
	void Start () {
		GameController.IsGameOver = true;
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		currentIdleTime += Time.deltaTime;
		if (currentIdleTime > timeToWait) {
			ProceedToNextScene();
		}
	}

	void ProceedToNextScene () {
		// Proceed to next scene
		gameController.StartCoroutine ("changeScene");
	}
}
