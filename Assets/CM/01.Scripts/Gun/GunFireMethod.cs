using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GunFireMethod : MonoBehaviour{
    private CinemachineImpulseSource _impulseSource;
    [SerializeField] private Transform firePoint;
    public UnityEvent OnFire;
    [SerializeField] private Vector2 _shakePower;
    [SerializeField] private float _shakeDuration;

    private void Awake(){
        _impulseSource = GetComponentInParent<CinemachineImpulseSource>();
    }

    public void HandleGunFire(){
        Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = quaternion.identity;
        _impulseSource.m_DefaultVelocity = _shakePower;
        _impulseSource.m_ImpulseDefinition.m_ImpulseDuration = _shakeDuration;
        _impulseSource.GenerateImpulse();
        OnFire?.Invoke();
    }
}