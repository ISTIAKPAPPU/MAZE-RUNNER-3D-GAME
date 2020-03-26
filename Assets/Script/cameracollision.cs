using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracollision : MonoBehaviour
{
    // Start is called before the first frame update
    public float mindistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 5.0f;
    Vector3 dollyDir;
    public Vector3 dollyDiradjusted;
    public float distance;
    Collider other;
    //public static bool camerahit = false;

    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void  Update()
    {
       
                Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
                RaycastHit hit;
                if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
                {
                    distance = Mathf.Clamp((hit.distance * 0.07f), mindistance, maxDistance);
                   // camerahit = true;
                    Debug.Log("mid");
        }
                else
                {
                    distance = maxDistance;
                    //camerahit = false;
                }
               
                transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        }
    }

