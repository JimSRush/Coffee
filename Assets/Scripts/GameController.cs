using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject scene1, scene2, scene3, scene4;
	public static float totalTimeSpentDrinkingCoffee;


	// Use this for initialization
	void Start () {
		StartCoroutine ("SwitchScenesOverTime");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SwitchScenesOverTime() {

		GameObject go = Object.Instantiate (scene1);
		yield return new WaitForSeconds (5);
		go = Object.Instantiate (scene2);
		yield return new WaitForSeconds (5);
	}


}
