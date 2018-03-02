using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void timedAction();

    public static event timedAction TimeUp;

    public float timeToAction = 20f;
    private float currentTime = 0;

	// Use this for initialization
	void Start () {
        RadioController.OnCrash += this.OnCrash;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime >= timeToAction)
        {
            currentTime = 0;
            if (TimeUp != null)
                TimeUp();
        }
	}

    void OnCrash()
    {
        currentTime = 0;
    }
}
