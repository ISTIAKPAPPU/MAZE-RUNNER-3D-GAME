using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class new_game : MonoBehaviour {

	public AudioSource press_start;

    public void PressNewGame(){
		press_start.Play ();
        StartCoroutine (DoFadeout ());
        StartCoroutine (Delay ());
        // SceneManager.LoadScene("level_00_tutorial");
        //FindObjectOfType<ProgressSceneLoader>().LoadScene("SelectStage");
    }

	IEnumerator DoFadeout (){
		CanvasGroup fade = GameObject.FindGameObjectWithTag ("Fade").GetComponent<CanvasGroup> ();
		Debug.Log ("Fading out.");
		fade.alpha = 0;
		while (fade.alpha < 1) {
			fade.alpha += Time.deltaTime / 3;
			yield return null;
		}
	}

	IEnumerator Delay () {
		yield return new WaitForSeconds (1);
        //SceneManager.LoadScene ("level_00_tutorial");
        //FindObjectOfType<ProgressSceneLoader>().LoadScene("SelectStage");
       SceneManager.LoadScene("SelectStage");
    }
}
