using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;

public class start_gradient_fader : MonoBehaviour {

	public CanvasGroup start_gradient;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float pingPong = Mathf.PingPong (Time.time * 0.5f, 0.9f);
		start_gradient.alpha = (pingPong);
		
	}
}
