using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] scenePrefabs;
	private GameObject currentScene;
	private int currentScenePosition;
	public static float totalTimeSpentDrinkingCoffee;
	private Fade fader;
	public Canvas c;

	//public Canvas c

//	// Use this for initialization
//	void Start () {
//		StartCoroutine ("SwitchScenesOverTime");
//	}
	
	void Start() {
		fader = c.GetComponent<Fade> ();
		fader.FadeIn ();
	}
		
	void Update () {
	}

	void changeScene() {
		fader.FadeOut ();
		currentScenePosition++;
		DestroyObject (currentScene);
		if (currentScenePosition < scenePrefabs.Length) {
			currentScene = scenePrefabs [currentScenePosition];
			Object.Instantiate (currentScene);
		} else {
			//endgame scenario
		}


	}
//
//	IEnumerator SwitchScenesOverTime() {
//
//		GameObject go = Object.Instantiate (scene1);
//		yield return new WaitForSeconds (sceneLength);
//		go = Object.Instantiate (scene2);
//		yield return new WaitForSeconds (5);
//
//

}
