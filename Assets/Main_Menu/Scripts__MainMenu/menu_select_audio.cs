using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_select_audio : MonoBehaviour {

	bool upIsPressed = false;
	bool downIsPressed = false;
	bool isNeutral = true;

	public AudioSource menu_select;
	
	// Update is called once per frame
	void Update () {

		float analogueStick = Input.GetAxis ("Vertical");

		if (analogueStick < -0.5f && !downIsPressed) {
			isNeutral = false;
			downIsPressed = true;
			sound ();
		} else if (analogueStick > 0.5f && !upIsPressed) {
			isNeutral = false;
			upIsPressed = true;
			sound ();
		} 
			
		else if (analogueStick == 0 && !isNeutral) {
			isNeutral = true;
			downIsPressed = false;
			upIsPressed = false;
		}

		if (Input.GetButtonDown ("Vertical")) {
			sound ();
		}
	}

	void sound(){
		Debug.Log ("menu select sound");
		menu_select.Play ();
		return;
	}
}
