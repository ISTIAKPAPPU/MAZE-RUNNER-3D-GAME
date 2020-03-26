using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float CameraMoveSpeed = 100.0f;
    public GameObject CameraFollowObj;
    Vector3 FollowPOS;
    public float mxclampAngle = 90.0f;
    public float minclampAngle = -22.5f;
    public float inputSensitivity =15.0f;
    public GameObject CameraObj;
    public GameObject PlayerObj;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public float inputX;
    public float inputZ;
    public FixedTouchField touchField;



    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = touchField.TouchDist.x;
        inputZ = touchField.TouchDist.y;
        finalInputX = inputX ;
        finalInputZ = inputZ ;
        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, minclampAngle, mxclampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

    }
    void LateUpdate()
    {
        CameraUpdater();
    }
    void CameraUpdater()
    {
  
        Transform target = CameraFollowObj.transform; 

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
