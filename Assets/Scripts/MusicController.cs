using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

	public AudioMixer masterMixer;
	public AudioMixerSnapshot[] snapshots;
	public AudioMixerSnapshot gameoverSnapshot;
	public float fadeTime = 5.0f;
	private int currentSnapshot = 0;
	private float[] timeGoals = new float[]{0.0f, 1.0f, 5.0f, 10.0f, 15.0f, 20.0f, 30.0f, 10000.0f};
	private bool isGameOver = false;

	// Update is called once per frame
	void Update () {
		if (!GameController.IsGameOver) {
			if(GameController.totalTimeSpentDrinkingCoffee >= timeGoals[currentSnapshot]) {
				NextSnapshot();
				Debug.Log("Transitioning to snapshot '" + snapshots[currentSnapshot].name + "'");
			}
		} else {
			if (!isGameOver) {
				Debug.Log("Transitioning to game over music");
				isGameOver = true;
				gameoverSnapshot.TransitionTo(fadeTime * 2.5f);
			}
		}
	}

	void NextSnapshot() {
		currentSnapshot = (currentSnapshot + 1);
		if (currentSnapshot < snapshots.Length) {
			AudioMixerSnapshot snapshot = snapshots[currentSnapshot];
			snapshot.TransitionTo(fadeTime);
		}
	}
}
