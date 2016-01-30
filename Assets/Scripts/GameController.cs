using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject scene1, scene2, scene3, scene4;
	public static float totalTimeSpentDrinkingCoffee;
	public static float sceneLength;
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

	IEnumerator SwitchScenesOverTime() {

		GameObject go = Object.Instantiate (scene1);
		yield return new WaitForSeconds (sceneLength);
		go = Object.Instantiate (scene2);
		yield return new WaitForSeconds (5);


	}
}
