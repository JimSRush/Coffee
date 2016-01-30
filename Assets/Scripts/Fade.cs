using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	CanvasGroup cg;
	public float FadeTime;

	public void FadeIn() {
		StartCoroutine (DoFadeIn ());
	}

	public void FadeOut(){
		StartCoroutine (DoFadeOut ());
	}

	IEnumerator DoFadeIn(){
		GameController.IsInputEnabled = false;
		cg = GetComponent<CanvasGroup> ();
		while (cg.alpha > 0) {
			cg.alpha -= Time.deltaTime / FadeTime;
			yield return null;
		}
		GameController.IsInputEnabled = true;
		yield return null;
	}

	IEnumerator DoFadeOut() {
		Debug.Log ("Fading out");
		GameController.IsInputEnabled = false;
		cg = GetComponent<CanvasGroup> ();
		while (cg.alpha < 1) {
			cg.alpha += Time.deltaTime / FadeTime;
			yield return null;
		}
		GameController.IsInputEnabled = true;
		yield return null;
	}

}
