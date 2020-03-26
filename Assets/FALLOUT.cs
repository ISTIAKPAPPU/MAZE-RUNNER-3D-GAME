using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FALLOUT : MonoBehaviour
{
    // Start is called before the first frame update
    static public bool fall = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("player");
            fall = true;
        }
    }
}
