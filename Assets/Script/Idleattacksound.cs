using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idleattacksound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;
    public bool check = false;
    public static bool playerhitenemy = false;

   

   
   

    // Use this for initialization
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void idleattack()
    {
        
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
        check = true;
    }
    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            if (check == true)
            {
                //Check if player fire animation going on
                  check = false;
                playerhitenemy = true;
                
                //Get enemy object and destory
                if (EnemyHealth.zerohealth == true)
                {
                GameObject enemy = other.transform.gameObject;
                enemy.tag = "deadenemy";
                enemy.GetComponent<Animator>().SetTrigger("dead");
              
                //Remove Box Collider did this so player can pass through the enemy after dead
               
                Destroy(enemy.GetComponent<BoxCollider>(), 0.5f);
            



                //Player is not underattack anymore
                    GameLogic.isPlayerUnderAttack = false;

                //Play Shoot Particle on sword
                GameObject Swordobj;
                Swordobj = GameObject.FindGameObjectWithTag("Sword");
                Swordobj.transform.Find("Particle").GetComponent<ParticleSystem>().Play();
                
                //Player Dead Sound
                AudioScript.enemyHitSoundPlay();

                //Enemies left Count
                GameLogic.enemiesLeft--;


                    EnemyHealth.zerohealth = false;

                    StartCoroutine(WAIT(enemy));
                    
                  
                }
 
            }
        }
        else
        {
            check = false;
        }
    }
    IEnumerator WAIT(GameObject enemy)
    {
        
        yield return new WaitForSeconds(2);
        EnemyHealth.currentHealth = 100;
        //Destroy Enemy
        Destroy(enemy, 1.0f);

    }

}
