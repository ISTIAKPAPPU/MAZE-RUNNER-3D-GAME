using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    //public int currentHealth { get; private set; }
    public static int currentHealth;
    public static bool zerohealth = false;

    public event Action<float> OnHealthPctChanged = delegate { };
    private void OnEnable()
    {
        currentHealth = maxHealth;
        //OnHealthAdded(this);
    }
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }
    private void Update()
    {
       
        if (Idleattacksound.playerhitenemy == true)
        {
            Debug.Log("Before===========" + currentHealth);
             ModifyHealth(-50);
            Debug.Log("After===========" + currentHealth);
            Idleattacksound.playerhitenemy = false;

        }
        if (currentHealth == 50)
        {
            zerohealth = true;
        }
     
           
    }


}
