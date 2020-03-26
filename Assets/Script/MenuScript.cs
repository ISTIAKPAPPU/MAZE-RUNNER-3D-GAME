using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    bool setMenuOneTime;

    //Get All Menu Items
    GameObject Sword;
    GameObject joystick;
    GameObject jumpbutton;

    GameObject btnBack;

    //End Menu Items
    GameObject endMenu;
    Text txtGameResult;
    Image imgStars;
    Button btnMenu1;
    Button btnMenu2;

    //Stars Texture
    public Sprite imgStarZero;
    public Sprite imgStarOne;
    public Sprite imgStarTwo;
    public Sprite imgStarThree;

    //Navigation Textures
    public Sprite imgNavOpen;
    public Sprite imgNavClose;

    //Get navigation
    GameObject navObj;
    GameObject btnNav;

    //Can use touch
    bool canUseTouch;

    // Use this for initialization
    void Start () {

        //Can Use Touch
        Sword = GameObject.Find("Canvas/Sword");
        joystick = GameObject.Find("Canvas/Joystick");
        jumpbutton = GameObject.Find("Canvas/Button");

        //Back Button
        btnBack = GameObject.Find("Canvas/btnBack");

        //Get Navigation button
        btnNav = GameObject.Find("Canvas/btnNav");
        navObj = GameObject.Find("Stage/Arrows");
        canShowNavigation();

        //End Menu Items
        endMenu = GameObject.Find("Canvas/EndMenu");
        txtGameResult = GameObject.Find("Canvas/EndMenu/txtGameResult").GetComponent<Text>();
        imgStars = GameObject.Find("Canvas/EndMenu/imgStars").GetComponent<Image>();
        btnMenu1 = GameObject.Find("Canvas/EndMenu/btnMenu1").GetComponent<Button>();
        btnMenu2 = GameObject.Find("Canvas/EndMenu/btnMenu2").GetComponent<Button>();
        endMenu.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (GameLogic.isGameOver)
        {
            if (!setMenuOneTime)
            {
                setMenuOneTime = true;
                setMenuUI();
            }
        }

        //Press Escape Key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            btnBackToSelectStage();
        }

    }

    bool isGameWin;
    void setMenuUI()
    {
        if (GameLogic.isTreausreCollected)
            isGameWin = true;

        //Hide etc buttons
        Sword.SetActive(false);
        joystick.SetActive(false);
        jumpbutton.SetActive(false);

        //End Menu Active
        endMenu.SetActive(true);
        if (isGameWin)
        {
            txtGameResult.text = "You Win";
            btnMenu1.GetComponentInChildren<Text>().text = "Next Stage";
            btnMenu2.GetComponentInChildren<Text>().text = "Play Again";

            //Set Stars
            string currentStage = PlayerPrefs.GetString("CurrentStage");//e.g Stage1
            string currentStageStars = PlayerPrefs.GetString(currentStage + "StarsLocal");//e.g Stage1StarsLocal
            if (currentStageStars == "one")
            {
                imgStars.GetComponent<Image>().overrideSprite = imgStarOne;
            }
            else if (currentStageStars == "two")
            {
                imgStars.GetComponent<Image>().overrideSprite = imgStarTwo;
            }
            else
            {
                imgStars.GetComponent<Image>().overrideSprite = imgStarThree;
            }

            //*** If End Game ****
            if (PlayerPrefs.GetString("NextStage") == "Stage3")
            {
                txtGameResult.text = "Congrats";
                btnMenu1.GetComponentInChildren<Text>().text = "Press Me!";
                btnMenu2.gameObject.SetActive(false);
                Debug.Log("***END GAME***");
            }
            
        }
        else
        {
            txtGameResult.text = "Game Over";
            btnMenu1.GetComponentInChildren<Text>().text = "Play Again";
            btnMenu2.GetComponentInChildren<Text>().text = "Back";

            //Set Star
            imgStars.GetComponent<Image>().overrideSprite = imgStarZero;
        }

        
    }


    public void btnMenuOneM()
    {
        Debug.Log("play again");
        if (isGameWin)
        {
            //Next Stage
            string nextStage = PlayerPrefs.GetString("NextStage");//e.g Stage2
           
            //Set Current Stage to next stage
            PlayerPrefs.SetString("CurrentStage", nextStage);

            //*** If End Game ****
            if (PlayerPrefs.GetString("NextStage") == "Stage3")
            {
                SceneManager.LoadScene("EndStory");
            }
            else
            {
                SceneManager.LoadScene(nextStage);
            }
        }
        else
        {
            
            //Play Again
            string currentStage = PlayerPrefs.GetString("CurrentStage");//e.g Stage1
            SceneManager.LoadScene(currentStage);
        }
    }

    public void btnMenuTwoM()
    {
        if (isGameWin)
        {
            //Play Again
            string currentStage = PlayerPrefs.GetString("CurrentStage");//e.g Stage1
            SceneManager.LoadScene(currentStage);
        }
        else
        {
            //Back
            SceneManager.LoadScene("SelectStage");
        }
    }

    public void btnBackToSelectStage()
    {
        SceneManager.LoadScene("SelectStage");
    }

    //Navigation
    void canShowNavigation()
    {
        string currentStage = PlayerPrefs.GetString("CurrentStage");//e.g Stage1
        string currentNav = currentStage + "Nav";//e.g Stage1Nav
        if (PlayerPrefs.GetString(currentNav) == "Yes")
        {
            navOpenBool = true;
        }
        else
        {
            //Hide Navigation
            btnNav.SetActive(false);
            navObj.SetActive(false);
        }
    }

    //Navigation UI
    bool navOpenBool;
    public void btnNavM()
    {
        if (navOpenBool)
        {
            navOpenBool = false;
            btnNav.GetComponent<Button>().image.overrideSprite = imgNavClose;
            navObj.SetActive(false);
        }
        else
        {
            navOpenBool = true;
            btnNav.GetComponent<Button>().image.overrideSprite = imgNavOpen;
            navObj.SetActive(true);
        }

        Debug.Log("NAV XXX");

    }

}
