using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

	public AudioMixer masterMixer;
	public AudioMixerSnapshot[] snapshots;
	public float fadeTime = 10.0f;
	private int currentSnapshot = 0;
	private float[] timeGoals = new float[]{0.0f, 5.0f, 10.0f, 15.0f, 25.0f, 50.0f, 75.0f, 100.0f};

	// Update is called once per frame
	void Update () {
		if(GameController.totalTimeSpentDrinkingCoffee >= timeGoals[currentSnapshot]) {
			NextSnapshot();
			Debug.Log("Transitioning to snapshot '" + snapshots[currentSnapshot].name + "'");
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
