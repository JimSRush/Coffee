using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicChanger : MonoBehaviour {

	public AudioMixer masterMixer;
	public AudioMixerSnapshot[] snapshots;
	public float fadeTime = 10.0f;
	private int currentSnapshot = 0;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.M)) {
			currentSnapshot = (currentSnapshot + 1) % snapshots.Length;
			AudioMixerSnapshot snapshot = snapshots[currentSnapshot];
			snapshot.TransitionTo(fadeTime);
		}
	}
}
