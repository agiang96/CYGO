using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class KeyboardMove : MonoBehaviour
{
    public bool walkStatus = true;
    public float speed = 6.0f;
    public float gravity = 0;
    private CharacterController _charController;

   


    public enum SPACESTATE { EMPTY = 0, CRATE = 1, COLLIDER = 2 };
    private Collider[] Colliders = null;
    private Transform LastBox = null;
    private Transform ThisTransform = null;

    // Use this for initialization  
    void Start()
    {
       
        _charController = GetComponent<CharacterController>();
    }
   
    // Update is called once per frame  
    void Update()
    {
       
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        if (walkStatus) { 
            _charController.Move(movement);
        }
    }

    public SPACESTATE PointState(Vector3 Point)
    {
        //Cycle through colliders and test for collision
        foreach (Collider C in Colliders)
        {
            //Point intersects a collider - determine type
            if (C.bounds.Contains(Point) && !C.gameObject.CompareTag("End"))
            {
                if (C.gameObject.CompareTag("Crate"))
                {
                    //Get reference to crate
                    LastBox = C.gameObject.transform;

                    return SPACESTATE.CRATE; //Point is in crate
                }
                else
                    return SPACESTATE.COLLIDER; //Else point is in collider
            }
        }

        //Point not in collider - space is empty
        return SPACESTATE.EMPTY;
    }
   
}
