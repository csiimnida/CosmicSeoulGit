using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    private CinemachineImpulseSource impulseSource;
    [SerializeField] private Vector2 _shakePower;
    [SerializeField] private float _duration;

    private void Start(){
        impulseSource = GetComponentInParent<CinemachineImpulseSource>();
    }

    public void Shake(){
        impulseSource.m_DefaultVelocity = _shakePower;
        impulseSource.m_ImpulseDefinition.m_ImpulseDuration = _duration;
        impulseSource.GenerateImpulse();
    }
}
