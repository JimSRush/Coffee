using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour {

	public Image coveringPanelFadeIn;
	public Image coveringPanelFadeOut;
	public float fadeTime;
	Color toFadeTo;

	// Use this for initialization
//	void Start () {
////		startFadeOut ();
////		startFadeIn();
//		startFadeOut();
//	}
	void Awake() {
		startFadeOut ();
	}




	void startFadeIn() {
		Color colorToFadeInTo = new Color (0f, 0f, 0f, 0f);
		coveringPanelFadeIn.CrossFadeColor (colorToFadeInTo, fadeTime, true, true);
	}

	void startFadeOut() {

		Color colorToFadeOutTo = new Color (0f, 1.0f, 0f, 0.9f);
		coveringPanelFadeOut.alpha
		coveringPanelFadeOut.CrossFadeColor (colorToFadeOutTo, fadeTime, true, true);
//		coveringPanelFadeIn.color = colorToFadeOutTo;
//		coveringPanelFadeIn.CrossFadeAlpha(1.0f, fadeTime * Time.deltaTime, false);
	}


}
