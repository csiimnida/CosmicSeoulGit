using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour{
    
    public static EnemyManager Instance;
    
    [SerializeField] private Transform BloodBoss1Page;
    [SerializeField] private GameObject BloodBoss2PagePrefab;
    [SerializeField] GameObject BloodEffect;
    [SerializeField] private float waitTime = 3f;

    private void Awake(){
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public void Start2Page(){
        StartCoroutine(CreateBloodBoss2Page());
    }



    private IEnumerator CreateBloodBoss2Page(){
        Instantiate(BloodEffect, BloodBoss1Page.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        BloodBoss2PagePrefab.transform.position = new Vector2(BloodBoss1Page.position.x, BloodBoss1Page.position.y - 0.5f);
        Destroy(BloodBoss1Page.gameObject);
        Destroy(BloodEffect);
    }
}
