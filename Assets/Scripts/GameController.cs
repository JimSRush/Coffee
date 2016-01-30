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
	public static bool IsInputEnabled;

	void Start() {
		currentScene = Object.Instantiate (scenePrefabs[0]);
		Debug.Log (currentScene.ToString ());
		fader = c.GetComponent<Fade> ();
		fader.FadeIn ();
	}

	IEnumerator changeScene() {
		ChangingScene = true;
		fader.FadeOut ();
		yield return new WaitForSeconds (8);
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

	public bool IsChangingScene () {
		return ChangingScene;
	}
}
