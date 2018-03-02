using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawn : MonoBehaviour {

    public static float epsilon = 0.2f;

    public float smooth = 1f;
    public float angularVelocity = 30f;

    private Vector2 newPosition;

    public Transform[] Objectives;

	// Use this for initialization
	void Start () {
        newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        ChangingPosition();
        float z = transform.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0f, 0f, z + angularVelocity);

    }

    void ChangingPosition()
    {
        transform.position = Vector2.Lerp(transform.position, newPosition, Time.deltaTime * smooth);
        Vector3 dif = transform.position - (Vector3)newPosition;

        if ( dif.magnitude < epsilon )
        {
            int i = Random.Range(0, Objectives.Length);
            newPosition = Objectives[i].position;
        }
    }
}
