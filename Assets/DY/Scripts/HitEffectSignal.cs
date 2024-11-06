using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectSignal : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

   public void ParticleEmit()
    {
        particle.Play();
    }
}
