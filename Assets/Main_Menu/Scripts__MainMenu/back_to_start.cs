using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class back_to_start : MonoBehaviour {


	public void ToStart () {
		SceneManager.LoadScene ("00_start_screen");
	}
}
