using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour {

    public ParticleSystem yellWallParticleSystem;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Yell"))
        {
            ParticleSystem particleSystem = (ParticleSystem)Instantiate(yellWallParticleSystem, 
                collider.transform.position, collider.transform.rotation);
            Destroy(collider.gameObject);

            Destroy(particleSystem.gameObject, particleSystem.main.startLifetime.constant);

        }
    }
}
