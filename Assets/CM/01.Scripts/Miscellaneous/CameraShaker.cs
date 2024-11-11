using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource _source;
    [SerializeField] private float _shakePower;

    public void Shake(){
        _source.GenerateImpulse(_shakePower);
    }
}
