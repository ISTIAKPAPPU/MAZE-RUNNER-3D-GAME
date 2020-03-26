using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowTo : MonoBehaviour {

    public Sprite forwardImage1;
    public Sprite forwardImage2;

    Button btnForward;
    Text txtSkip;
    Button btnBack;

   
    void Start () {


        //Get Forward Button
        btnForward = GameObject.Find("Canvas/btnForward").GetComponent<Button>();

        //Get Forward Message
        txtSkip = GameObject.Find("Canvas/txtSkip").GetComponent<Text>();

        //Get Back Button
        btnBack = GameObject.Find("Canvas/btnBack").GetComponent<Button>();

        //Coming from main screen controls
        if (PlayerPrefs.GetString("FromMainScreenControls") == "yes")
        {
            PlayerPrefs.SetString("FromMainScreenControls", "no");
            btnForward.gameObject.SetActive(false);
            txtSkip.gameObject.SetActive(false);
        }
        else
        {
            //Hide Back Button
            btnBack.gameObject.SetActive(false);

            //Invoke Next Blink
            Invoke("forwardImageBlink", 1.0f);
        }

        //Set How To Already Loaded
        if (PlayerPrefs.GetString("HowToAlreadyLoaded") == "")
        {
            PlayerPrefs.SetString("HowToAlreadyLoaded", "yes");
        }

    }

    //Forward Blink Button
    int forwardCount;
    void forwardImageBlink()
    {
        if (forwardCount == 0)
        {
            forwardCount = 1;
            btnForward.image.overrideSprite = forwardImage2;
        }
        else
        {
            forwardCount = 0;
            btnForward.image.overrideSprite = forwardImage1;
        }

        Invoke("forwardImageBlink", 1.0f);

    }
	
	// Update is called once per frame
	void Update () {

        //Press Escape Key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            btnBackM();
        }

    }

    //Goto FirstStage
    public void gotoFirstStageM()
    {
        FindObjectOfType<ProgressSceneLoader>().LoadScene("Stage1");
    }

    //Back Screen
    public void btnBackM()
    {
        SceneManager.LoadScene("01_main_menu");
    }

}
