using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunFireMethod : MonoBehaviour{
    [SerializeField] private Transform firePoint;

    public void HandleGunFire(){
        Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = quaternion.identity;
    }
}