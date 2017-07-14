using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rigidBody;
    public float speed;
    void Start () {
        rigidBody = GetComponent(typeof(Rigidbody)) as Rigidbody;
        rigidBody.velocity = transform.up * speed;
    }
	
}
