using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] scenePrefabs;
	private GameObject currentScene;
	private int currentScenePosition = 0;
	public static float totalTimeSpentDrinkingCoffee;
	private Fade fader;
	public Canvas c;
	private bool ChangingScene = false;
	private int goalTime = 5;

	//public Canvas c

	//	// Use this for initialization
	//	void Start () {
	//		StartCoroutine ("SwitchScenesOverTime");
	//	}

	void Start() {
		//currentScene = 
		currentScene = Object.Instantiate (scenePrefabs[0]);
		//	Debug.Log (GameObject.FindGameObjectWithTag ("Paris Scene"));
		Debug.Log (currentScene.ToString ());
		fader = c.GetComponent<Fade> ();
		fader.FadeIn ();
		StartCoroutine ("Wait");	
	}

	void Update () {
		if (totalTimeSpentDrinkingCoffee > goalTime && !ChangingScene) {
			StartCoroutine ("changeScene");
			ChangingScene = true;
		}

	}

	IEnumerator changeScene() {
		fader.FadeOut ();
		yield return new WaitForSeconds (8);
		goalTime += 15;
		DestroyObject (currentScene);
		currentScenePosition++;
		if (currentScenePosition < scenePrefabs.Length) {
			currentScene = scenePrefabs [currentScenePosition];
			currentScene = Object.Instantiate (currentScene);
			ChangingScene = false;
			fader.FadeIn ();

		} else {
			//endgame scenario
		}
	}
}
