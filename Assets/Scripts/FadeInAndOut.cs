using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour {

	public Image coveringPanel;
	public float fadeTime;
	Color toFadeTo;

	// Use this for initialization
	void Start () {
		startFade ();
	}

	public void startFade() {
		Color colorToFadeTo = new Color (1f, 1f, 1f, 0f);
		coveringPanel.CrossFadeColor (colorToFadeTo, fadeTime, true, true);
	}

	


}
