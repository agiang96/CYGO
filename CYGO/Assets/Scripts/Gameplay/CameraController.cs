using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //方向灵敏度  
    public float sensitivityX = 10F;
    public float sensitivityY = 10F;

    //上下最大视角(Y视角)  
    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    void Update()
    {
         
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
           
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

    void Start()
    {
        // Make the rigid body not change rotation  
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }
}
