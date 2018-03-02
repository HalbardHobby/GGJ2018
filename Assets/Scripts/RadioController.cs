using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class RadioController : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    private new Rigidbody2D rigidbody;
    private AudioSource source;
    private new Collider2D collider;

    public delegate void onCrash();
    public static event onCrash OnCrash;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        collider = GetComponent<Collider2D>();
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax)
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnCrash != null)
            OnCrash();
        source.Play();
        StartCoroutine(crash());
    }

    IEnumerator crash()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        collider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        collider.enabled = true;
    }

}

[System.Serializable]
public struct Boundary
{
    public float xMin, xMax, yMin, yMax;
}