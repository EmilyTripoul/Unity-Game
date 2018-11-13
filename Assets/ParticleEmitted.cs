using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleEmitted : MonoBehaviour
{


    private float lifetime;
    private float fadeDelay = 5f;
    private float fadeDuration=1f;
    private float updateFrequency = 0.05f;

    // Use this for initialization
    void Start () {
    }
    
    IEnumerator FadeAndKill()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        TrailRenderer trailRnderer = GetComponent<TrailRenderer>();

        yield return new WaitForSeconds(fadeDelay);
        if (fadeDuration > 0.1)
        {
            for (float f = 1f; f >= 0; f -= updateFrequency / fadeDuration)
            {
                Color c1 = renderer.material.color;
                c1.a = f;
                renderer.material.color = c1;
                Color c2 = trailRnderer.material.GetColor("_TintColor");
                c2.a = f*f;
                trailRnderer.material.SetColor("_TintColor", c2);
                yield return new WaitForSeconds(updateFrequency);
            }
        }
        Destroy(this.gameObject);
    }

    public void StartFadeAndKill(float delay, float duration)
    {
        fadeDelay = delay;
        fadeDuration = duration;
        StartCoroutine("FadeAndKill");
    }
}
