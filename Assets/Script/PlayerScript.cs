using UnityEngine;

public class PlayerScript : MonoBehaviour
{
 

    //Player Health
    static public int playerHealth;//Static Variable set in start

    //Rigid Body
    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        //Set Player Health Static Variable
        playerHealth = 8;//6;

        //Get Player Ridgit Body
        rb = GetComponent<Rigidbody>();

    }

    bool isPlayerOnGround;
    void OnCollisionStay()
    {
     

        isPlayerOnGround = true;
    }

    //bool landSoundLogicBool;
    void OnCollisionEnter(Collision col)
    {
      

        //Player Touch Game Over Plane
        if (col.gameObject.name == "GameOverPlane")
        {
            //Set player health zero
            playerHealth = 0;
        }

    }

    void OnCollisionExit()
    {

    }

    //On Trigger enter
    void OnTriggerEnter(Collider col)
    {
        if (col.tag =="treasure")
        {
            GameLogic.isTreausreCollected = true;
        }
    }

}
