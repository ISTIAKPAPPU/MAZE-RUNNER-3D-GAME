using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class mix_levels : MonoBehaviour {

	public AudioMixer masterMixer;

	public void SetSfxLvl(float sfxLvl){
		masterMixer.SetFloat ("soundVol", sfxLvl);
	}

	public void SetMusicLvl(float musicLvl){
		masterMixer.SetFloat ("musicVol", musicLvl);
	}
}
