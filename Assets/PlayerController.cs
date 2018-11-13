using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 3.0f;

    private Rigidbody rigidBody;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
                                    // Use this for initialization
    void Start () {

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // GetAxisRaw is unsmoothed input -1, 0, 1
        float z = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        // normalize so going diagonally doesn't speed things up
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        // translate
        //transform.Translate(direction * speed * Time.deltaTime);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rigidBody.AddForce(direction * speed);
    }
}

