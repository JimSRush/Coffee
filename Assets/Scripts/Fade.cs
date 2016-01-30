using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	void Start(){
		FadeMe ();
	}

	public void FadeMe() {
		StartCoroutine (DoFadeIn ());
		Debug.Log ("Fading in");
		//StartCoroutine (DoFadeOut ());
		Debug.Log ("Fading out");

	}

	IEnumerator DoFadeIn(){
		CanvasGroup cg = GetComponent<CanvasGroup> ();
		while (cg.alpha > 0) {
			cg.alpha -= Time.deltaTime / 2;
			yield return null;
		}
		cg.interactable = false;
		yield return null;
	}

	IEnumerator DoFadeOut() {
		CanvasGroup cg = GetComponent<CanvasGroup> ();
		cg.alpha = 0f;
		while (cg.alpha < 255) {
			cg.alpha += Time.deltaTime / 2;
			yield return null;
		}
		cg.interactable = false;
		yield return null;
	}


}
