using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;

    public GameObject shot;
    public GameObject shotSpawn;
    public float fireDelta;
    private float myTime = 0.0F;

    public float speed;
    public float tilt;
    public Boundary boundary;

    private void Start()
    {
        rigidBody = GetComponent(typeof(Rigidbody)) as Rigidbody;
    }

    private void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > fireDelta)
        {
            fireDelta = myTime + fireDelta;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);

            fireDelta = fireDelta - myTime;
            myTime = 0.0F;
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rigidBody.velocity = movement * speed;

        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidBody.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        rigidBody.rotation = Quaternion.Euler(-90.0f, rigidBody.velocity.x * -tilt, 0.0f);
    }
    
}
