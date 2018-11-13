using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour {

    public int yellNumber = 9;
    public float duration = 10.0f;
    public float initialSpeed = 3.0f;
    private float initialDistance = 0.0f;
    public float fadeDuration = 0.0f;

    public void EmitObject(ParticleEmitted yellObject)
    {
        for (int i = 0; i < yellNumber; i++)
        {
            ParticleEmitted yellClone = (ParticleEmitted)Instantiate(yellObject, transform.position, transform.rotation);
            float angle = i * 360f / yellNumber;
            yellClone.transform.Rotate(new Vector3(0f, angle, 0f));
            yellClone.transform.Translate(new Vector3(initialDistance, 0f, 0f), Space.Self);

            Rigidbody rigidbody = yellClone.GetComponent<Rigidbody>();
            rigidbody.AddRelativeForce(new Vector3(initialSpeed, 0f, 0f));

            yellClone.StartFadeAndKill(duration, fadeDuration);
        }
    }
}
