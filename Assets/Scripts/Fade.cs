using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	CanvasGroup cg;

	public float FadeTime;

//	void Start(){
//		FadeIn ();
//	}

	public void FadeIn() {
		StartCoroutine (DoFadeIn ());
	}

	public void FadeOut(){
		StartCoroutine (DoFadeOut ());
	}

	IEnumerator DoFadeIn(){
		cg = GetComponent<CanvasGroup> ();
		while (cg.alpha > 0) {
			cg.alpha -= Time.deltaTime / FadeTime;
			yield return null;
		}
		cg.interactable = false;
		yield return null;
	}

	IEnumerator DoFadeOut() {
		cg = GetComponent<CanvasGroup> ();
		cg.alpha = 0f;
		while (cg.alpha < 255) {
			cg.alpha += Time.deltaTime / FadeTime;
			yield return null;
		}
		cg.interactable = false;
		yield return null;
	}


}
