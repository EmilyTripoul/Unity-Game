using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEmitter : ParticleEmitter
{

    public ParticleEmitted yellObject;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            EmitObject(yellObject);
        }
    }
}
