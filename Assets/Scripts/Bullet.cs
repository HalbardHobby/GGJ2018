using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    //public enum Trajectory { Straight, Sine};
    //public Trajectory trayectoria;

    public float StartSpeed;
    public float AngularSpeed;
    public float Acceleration;
    public float timeToDestroy = 10f;

    private new Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * StartSpeed;
        rigidbody.angularVelocity = AngularSpeed;
        Destroy(this.gameObject, timeToDestroy);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rigidbody.velocity = transform.up * rigidbody.velocity.magnitude + (transform.up * Acceleration * Time.deltaTime);
    }
}
