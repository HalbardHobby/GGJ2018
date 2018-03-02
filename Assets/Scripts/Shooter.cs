using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public Transform[] SpawnPoint;
    public int bullets;
    public float FanAngle;

    [Range(0.1f, 1)]
    public float SecondsToShoot;
    public float Step = 0.2f;
    public Bullet bullet;

    private float nextFire;

    // Use this for initialization
    void Start () {
        EventManager.TimeUp += StepUp;
        RadioController.OnCrash += StepDown;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + SecondsToShoot;
            for( int i = 0; i < SpawnPoint.Length; i++ )
            {
                Instantiate(bullet, SpawnPoint[i].position, SpawnPoint[i].rotation);
            }
        }
    }

    void StepUp()
    {
        if(SecondsToShoot > 0.1f)
        {
            SecondsToShoot -= Step;
        }
    }

    void StepDown()
    {
        if(SecondsToShoot < 1f)
        {
            SecondsToShoot += Step;
        }
    }
}
