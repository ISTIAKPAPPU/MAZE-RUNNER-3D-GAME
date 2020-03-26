using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

    static AudioSource[] audioSources;
    static bool isSoundOnBool;

	// Use this for initialization
	void Start () {

        audioSources = GetComponents<AudioSource>();

        string isSoundOn = PlayerPrefs.GetString("isSoundOn");
        if (isSoundOn == "on" || isSoundOn == "")
        {
            //Sound On
            isSoundOnBool = true;
        }
        else if (isSoundOn == "off")
        {
            //Sound Off
            isSoundOnBool = false;
        }

    }
    //Coin Sound Play
    public static void coinSoundPlay()
    {
        if (isSoundOnBool)
        {
           
            audioSources[3].Play();
        }
    }

    //Plater Hit
    public static void playerHitSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[5].isPlaying)
            {
                audioSources[5].Play();
            }
        }
    }

    //Enemy Hit
    public static void enemyHitSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[6].isPlaying)
            {
                audioSources[6].Play();
            }
        }
    }

    //Game Win
    public static void gameWinSoundPlay()
    {
        if (isSoundOnBool)
        {
            //Play Win Sound
            if (!audioSources[7].isPlaying)
            {
                audioSources[7].Play();
            }
        }
    }

    //Game Lose
    public static void gameLoseSoundPlay()
    {
        if (isSoundOnBool)
        {
            if (!audioSources[8].isPlaying)
            {
                audioSources[8].Play();
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
