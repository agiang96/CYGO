using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

   
    public bool bIsOnDestination = false;

    void OnTriggerStay(Collider Other)
    {
        if (Other.CompareTag("End"))
            bIsOnDestination = true;
    }
    void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("End"))
            bIsOnDestination = false;
    }
}
