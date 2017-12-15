using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TimeScript : MonoBehaviour {

    public Text timeText;
    private float timeCount = 300f;
    private float minutes = 0;
    private float seconds = 0;

    Animator anim; 

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        timeText.text = "Time Left: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    // Update is called once per frame
    void Update () {

        if (timeCount > 0.1)
        {
            timeCount -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeCount / 60f);
            int seconds = Mathf.RoundToInt(timeCount % 60f);
            timeText.text = "Time Left: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        if (timeCount <= 0.1)
        {
            anim.SetTrigger("GameOver"); 
        }
    }
}
