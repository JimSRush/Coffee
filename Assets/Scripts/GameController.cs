using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] scenePrefabs;
	private GameObject currentScene;
	private int currentScenePosition = 0;
	public static float totalTimeSpentDrinkingCoffee;
	private Fade fader;
	public Canvas c;

	//public Canvas c

//	// Use this for initialization
//	void Start () {
//		StartCoroutine ("SwitchScenesOverTime");
//	}
	
	void Start() {
		//currentScene = 
		currentScene = Instantiate (scenePrefabs[0]);
	//	Debug.Log (GameObject.FindGameObjectWithTag ("Paris Scene"));
		Debug.Log (currentScene.ToString ());
		fader = c.GetComponent<Fade> ();
		fader.FadeIn ();
		StartCoroutine ("Wait");
	}
		
	void Update () {
	}

	IEnumerator changeScene() {
		fader.FadeOut ();
		yield return new WaitForSeconds (6);
		DestroyObject (currentScene);
		currentScenePosition++;
		if (currentScenePosition < scenePrefabs.Length) {
			currentScene = scenePrefabs [currentScenePosition];
			Object.Instantiate (currentScene);
			fader.FadeIn ();	
		} else {
			//endgame scenario
		}


	}

	IEnumerator Wait() {
		//yield return new WaitForSeconds (10);
		StartCoroutine ("changeScene");
			
	}
}
