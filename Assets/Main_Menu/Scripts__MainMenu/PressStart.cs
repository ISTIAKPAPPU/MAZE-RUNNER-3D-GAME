using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour {

	public AudioSource press_start;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//if (Input.GetButtonDown ("Submit"))
			//press_start.Play ();
		
	}
    public void ToStart()
    {
        press_start.Play();
        SceneManager.LoadScene("01_main_menu");
        //SceneManager.LoadScene("MainMenu");
    }
}
