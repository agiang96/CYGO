using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanger : MonoBehaviour {
    
    private Crate[] Crates = null;
    private bool doorUnlock = false;
    Animator animator;
    private bool doorOpen;


    // Use this for initialization
    void Start ()
    {
        Crates = GameObject.FindObjectsOfType<Crate>();
        doorOpen = false;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (CheckForWin())
        {
            doorUnlock = true;
            //play sound
            Debug.Log("Boxes are placed right!");
        }
    }

    public bool CheckForWin()
    {
        foreach (Crate C in Crates)
        {
            if (!C.bIsOnDestination)
                return false; //If there is one or more crates not on destination then exit with false - no win situation
        }
        //Level completed
        return true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (doorUnlock && other.gameObject.CompareTag("Player"))
        {
            doorOpen = true;
            //play sound
            Doors("Open");  //call the Doors function
            FindObjectOfType<AudioManager>().Play("DoorOpen");
            Debug.Log("Enter");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (doorOpen)
        {
            doorOpen = false;
            //Doors("Close"); //call the Doors function
            Debug.Log("HIHIHIHI pricesss");
            animator.SetTrigger("Win");
            SceneManager.LoadScene("Credit");
        }
    }

    void Doors(string direction)    //call the animation
    {
        animator.SetTrigger(direction);
    }

}
