using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveEmitter : ParticleEmitter
{

    public ParticleEmitted yellNegativeObject;
    public ParticleEmitted yellPositiveObject;
    public float emitPeriod = 2.0f;
    public bool pulse = true;
    private bool activated = false;

    // Use this for initialization
    void Start () {
        if (pulse)
        {
            InvokeRepeating("Emit", 0, emitPeriod);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Yell") && !pulse)
        {
            Destroy(collider.gameObject);
            Emit();
        }
        if (collider.CompareTag("Player"))
        {
            activated = true;
            CancelInvoke("Emit");
            InvokeRepeating("Emit", 0, emitPeriod);
        }
    }
    void Emit()
    {
        if (activated)
        {
            EmitObject(yellPositiveObject);
        }
        else
        {
            EmitObject(yellNegativeObject);
        }
    }

}
