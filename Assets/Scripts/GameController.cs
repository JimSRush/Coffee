using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour, IMetric {

	public GameObject[] scenePrefabs;
	private GameObject currentScene;
	private int currentScenePosition = 0;
	public static float totalTimeSpentDrinkingCoffee;
	private Fade fader;
	public Canvas c;
	private bool ChangingScene = false;
	public static bool IsInputEnabled;
	public static bool IsGameOver = false;

	private MetricController metricController;

	void Start() {
		currentScene = Object.Instantiate (scenePrefabs[0]);
		metricController = GetComponent<MetricController>();
		totalTimeSpentDrinkingCoffee = 0.0f;
		Debug.Log (currentScene.ToString ());
		fader = c.GetComponent<Fade> ();
		IsGameOver = false;
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
			UpdateMetrics();
			metricController.PrintMetrics();
		}
	}

	public bool IsChangingScene () {
		return ChangingScene;
	}

	public MetricController MetricController () {
		return metricController;
	}

	public void UpdateMetrics() {
		metricController.totalTimeDrinking = totalTimeSpentDrinkingCoffee;
	}
}
