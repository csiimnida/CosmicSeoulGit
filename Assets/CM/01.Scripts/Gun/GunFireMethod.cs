using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunFireMethod : MonoBehaviour{
    [SerializeField] private float dispersion;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int AmmoCount = 5;
    private float randomRotation;
    
    public void HandleGunFire(){
        for (int i = 0; i < AmmoCount; i++)
        {
            randomRotation = Random.Range(-dispersion, dispersion);
            
            Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = new Quaternion(0, 0, randomRotation, 0);
        }
    }
}
