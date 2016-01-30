using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class TrainSFX : MonoBehaviour {

	public AudioMixerSnapshot[] snapshots;
	private SceneController trainScene;
	private int currentStage = 0;
	private float fadeTime;

	// Use this for initialization
	void Start () {
		trainScene = GetComponent<SceneController>();
		fadeTime = GameObject.FindGameObjectWithTag("Fader").GetComponent<Fade>().FadeTime;
		fadeTime *= 2.0f; // Hack - Get avoid logarithmic db dropoff

		currentStage++;
		snapshots[currentStage].TransitionTo(fadeTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (trainScene.IsLeavingScene()) {
			snapshots[snapshots.Length - 1].TransitionTo(fadeTime);
		}
	}
}
