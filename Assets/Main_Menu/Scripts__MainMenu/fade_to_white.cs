using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade_to_white : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DoFadein());
	}

	//Fade in
	IEnumerator DoFadein () {
		Debug.Log ("Fading in.");
		CanvasGroup fade = GetComponent<CanvasGroup> ();
		fade.interactable = false;
		fade.alpha = 1;
		while (fade.alpha > 0) {
			fade.alpha -= Time.deltaTime / 2;
			yield return null;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit"))
			StartCoroutine (DoFadeout ());
	}

	IEnumerator DoFadeout (){
		StopCoroutine (DoFadein ());
		CanvasGroup fade = GetComponent<CanvasGroup> ();
		Debug.Log ("Fading out.");
		fade.alpha = 0;
		while (fade.alpha < 1) {
			fade.alpha += Time.deltaTime;
			if (fade.alpha == 1)
				LoadLevel ("01_main_menu");
			yield return null;
		}
	}

	public void LoadLevel (string name) {
		Debug.Log ("Loading level: " + name);
		SceneManager.LoadScene (name);
	}
}
