using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>{
    [SerializeField] private Transform BloodBoss1Page;
    [SerializeField] private GameObject BloodBoss2PagePrefab;
    [SerializeField] private ParticleSystem BloodParticle;
    [SerializeField] private float waitTime = 3f;
    

    public void Start2Page(){
        StartCoroutine(CreateBloodBoss2Page());
    }



    private IEnumerator CreateBloodBoss2Page(){
        Instantiate(BloodParticle, BloodBoss1Page.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        Instantiate(BloodBoss2PagePrefab, new Vector2(BloodBoss1Page.position.x, BloodBoss1Page.position.y - 1f), Quaternion.identity);
        Destroy(BloodBoss1Page.gameObject);
        BloodParticle.Stop();
    }
}
