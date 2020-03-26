using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameLogic : MonoBehaviour {

    //Get UI
    Text txtCoins;
    Text txtTimer;
    Text txtPlayerHealth;

    //Total Coins
    int totalCoins;
    public static int coinsLeft;

    //Total Enemies Left
    public static int enemiesLeft;

    //Stage Timer
    int stageTimer;

    //Is Player Under Attack
    public static bool isPlayerUnderAttack;

    //Treasure Collected
    public static bool isTreausreCollected;

    //Score
    public static int totalScore;

    //Is Game Logic
    public static bool isGameOver;
    bool gameOverOneTimeLogic;

    //Get Player
    GameObject player;
    public GameObject ch;
    GameObject playerBodyMesh1;
    GameObject playerBodyMesh2;
    GameObject playerBodyMesh3;
    public ParticleSystem Blood;
    
   

    // Use this for initialization
    void Start()
    {
        //Static variables
        isPlayerUnderAttack = false;
        isGameOver = false;
        isTreausreCollected = false;
        totalScore = 0;

        //Get Player
        player = GameObject.FindGameObjectWithTag("player");
        playerBodyMesh1 = player.transform.Find("Adam_Adv_Hood").gameObject;
        playerBodyMesh2 = player.transform.Find("Adam_Adv_Shirt").gameObject;
        playerBodyMesh3 = player.transform.Find("Adam_Adv_paints").gameObject;


        //Get UI Elements
        txtCoins = GameObject.Find("Canvas/txtCoins").GetComponent<Text>();
        txtTimer = GameObject.Find("Canvas/txtTimer").GetComponent<Text>();
        txtPlayerHealth = GameObject.Find("Canvas/txtPlayerHealth").GetComponent<Text>();

        //Get total coins and timers
        totalCoins = GameObject.Find("Coins").transform.childCount;
        coinsLeft = totalCoins;

        //Get Total Enemies Count
        enemiesLeft = GameObject.Find("Enemies").transform.childCount;

        //Set stage timer
        timerForStage();

    }

    // Update is called once per frame
    void Update()
    {
        //Check if game is over
        //Game Over
        if (PlayerScript.playerHealth <= 0 || stageTimer <= 0 || FALLOUT.fall)
        {
            if (!gameOverOneTimeLogic)
            {
                gameOverOneTimeLogic = true;
                isGameOver = true;

                //Game Lose Sound Play
                AudioScript.gameLoseSoundPlay();

                //Game Lose Particle Play
                 getCameraGameObject().transform.Find("ParticleLose").GetComponent<ParticleSystem>().Play();

                //Hide Player Renderer
                playerBodyMesh1.GetComponent<Renderer>().enabled = false;
                playerBodyMesh2.GetComponent<Renderer>().enabled = false;
                playerBodyMesh3.GetComponent<Renderer>().enabled = false;
                Enable();

                Debug.Log("***GAME OVER***");
            }

            
        }

        //Check if all coins collected
        //Game Win
        if (isTreausreCollected)
        {
            if (!gameOverOneTimeLogic)
            {
                gameOverOneTimeLogic = true;
                isGameOver = true;

                //Unlock Next Stage
                unlockNextStage();

                //Game Win Sound Play
                AudioScript.gameWinSoundPlay();

                //Game Win Particle Play
                getCameraGameObject().transform.Find("ParticleWin").GetComponent<ParticleSystem>().Play();

                //Hide Player Renderer
                playerBodyMesh1.GetComponent<Renderer>().enabled = false;
                playerBodyMesh2.GetComponent<Renderer>().enabled = false;
                playerBodyMesh3.GetComponent<Renderer>().enabled = false;
                Debug.Log("vanish1");
                Enable();

                Debug.Log("***GAME WIN***");
            }
        }

        //Check if game is not over
        if (!isGameOver)
        {
            //Set UI Element total coins
            txtCoins.text = "Coins : " + totalScore;

            //Check Player Under Attack
            if (isPlayerUnderAttack)
            {
                
                if (!waitPlayerUnderAttack)
                {
                    waitPlayerUnderAttack = true;
                  //  Invoke("playerUnderAttack", 0.3f);//0.5
                  Invoke("enemyattack",8f);  
                }

                
              
                
                
            }
            else
            {
                if (playerBodyMesh1.GetComponent<Renderer>().material.color != Color.white)
                {
                    playerBodyMesh1.GetComponent<Renderer>().material.color = Color.white;
                    playerBodyMesh2.GetComponent<Renderer>().material.color = Color.white;
                    playerBodyMesh3.GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }
    // Character vanish
    public void Enable()
    {
        ch.SetActive(false);
        Debug.Log("vanish");
    }
    bool waitPlayerUnderAttack;
    void enemyattack()
     {
        waitPlayerUnderAttack = false;
        if (isPlayerUnderAttack)
        {
            Debug.Log("attack by enemy");
            PlayerScript.playerHealth--;

            //set player health ui |||
            setPlayerHealthUI();
            //getCameraGameObject().transform.Find("blood").GetComponent<ParticleSystem>().Play();

            playerBodyMesh1.GetComponent<Renderer>().material.color = Color.red;
            playerBodyMesh2.GetComponent<Renderer>().material.color = Color.red;
            playerBodyMesh3.GetComponent<Renderer>().material.color = Color.red;

            //Player Hit Sound
            if (PlayerScript.playerHealth >= 0)
            {
                Blood.Play();
                AudioScript.playerHitSoundPlay();
            }
        }


     }

    void timerForStage()
    {
        //Default
        stageTimer =1800;

        //Get current stage
        string currentStage = PlayerPrefs.GetString("CurrentStage");
        Debug.Log("Currentstage= "+currentStage);

        if (currentStage == "Stage1")
        {
            stageTimer = 60*3;
        }

        if (currentStage == "Stage2")
        {
            stageTimer = 60*3;
        }

        setTimerUI();
    }

    void setTimerUI()
    {
        if (!isGameOver)
        {
            if (!isTreausreCollected)
            {
                stageTimer--;

                if (stageTimer > -1)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(stageTimer);
                    //txtTimer.text = ts.ToString().Remove(0, 3);
                    txtTimer.text = ts.ToString();
                    Invoke("setTimerUI", 1.0f);
                }
            }
        }

    }

    void unlockNextStage()
    {
        string currentStage = PlayerPrefs.GetString("CurrentStage");//e.g Stage1
        string nextStage = currentStage.Replace("Stage", "");//e.g 1 in string
       
        int nextStageIncreament = Convert.ToInt32(nextStage);//e.g 1 in int
        nextStageIncreament++;//e.g 2 
        nextStage = "Stage" + nextStageIncreament;//e.g Stage2
        PlayerPrefs.SetString("NextStage", nextStage);//e.g Stage2
        PlayerPrefs.SetString(nextStage + "Unlocked", "Yes");//e,g Stage2Unlocked

        //Stage Stars Set
        setCurrentStageStars();

    }
    

    void setCurrentStageStars()
    {
        string currentStage = PlayerPrefs.GetString("CurrentStage");//e.g Stage1

        if (getHowMuchStars() == 1)
        {
            if (PlayerPrefs.GetString(currentStage + "Stars") != "two") //e.g Stage1Stars , two //If Already Greater Ignore
            {
                PlayerPrefs.SetString(currentStage + "Stars", "one");//e.g Stage1Stars , one
            }

            //Local Star value for MenuScript.cs
            PlayerPrefs.SetString(currentStage + "StarsLocal", "one");//e.g Stage1StarsLocal , one

        }
        else if (getHowMuchStars() == 2)
        {
            if (PlayerPrefs.GetString(currentStage + "Stars") != "three") //e.g Stage1Stars , three //If Already Greater Ignore
            {
                PlayerPrefs.SetString(currentStage + "Stars", "two");//e.g Stage1Stars , two
            }

            //Local Star value for MenuScript.cs
            PlayerPrefs.SetString(currentStage + "StarsLocal", "two");//e.g Stage1StarsLocal , two
        }
        else
        {
            PlayerPrefs.SetString(currentStage + "Stars", "three");//e.g Stage1Stars , three

            //Local Star value for MenuScript.cs
            PlayerPrefs.SetString(currentStage + "StarsLocal", "three");//e.g Stage1StarsLocal , three
        }
    }

    //Check how much stars
    int getHowMuchStars()
    {
        string currentStage = PlayerPrefs.GetString("CurrentStage");//e.g Stage1
        int stars = 1;


        //Stage 1
        if (currentStage == "Stage1")
        {
            if (stageTimer >= 90)
            {
                stars = 3;
            }
            else if (stageTimer >= 50)
            {
                stars = 2;
            }
            else
            {
                stars = 1;
            }
        }

        //Stage 2
        if (currentStage == "Stage2")
        {
            if (stageTimer >= 45)
            {
                stars = 3;
            }
            else if (stageTimer >= 30)
            {
                stars = 2;
            }
            else
            {
                stars = 1;
            }
        }

   

        return stars;

    }

    //Get Current Active Camera
    GameObject getCameraGameObject()
    {
        GameObject gameCamera;

        gameCamera = GameObject.FindGameObjectWithTag("MainCamera");


        return gameCamera;

    }

    //Set Player Health UI
    void setPlayerHealthUI()
    {
        //Set Player life
        string playerHealthLines = "";
        for (int i = 0; i < PlayerScript.playerHealth; i++)
        {
            playerHealthLines += "|";
        }

        //Set Color
        if (PlayerScript.playerHealth <= 4)//3
        {
            //pink
            txtPlayerHealth.text = "<color=#00ff00ff>Health</color> : <color=#ff0000ff>" + playerHealthLines + "</color>";
        }
        else if (PlayerScript.playerHealth <= 6)//7
        {
            //Yellow
            txtPlayerHealth.text = "<color=#00ff00ff>Health</color> : <color=#ffff00ff>" + playerHealthLines + "</color>";
        }
        else
        {
            //Green
            txtPlayerHealth.text = "<color=#00ff00ff>Health</color> : <color=#ffc0cb>" + playerHealthLines + "</color>";
        }
        

        //#00ff00ff green
        //#ffc0cb  pink
        //#ffff00ff yellow
        //#ff0000ff red
    }

}
