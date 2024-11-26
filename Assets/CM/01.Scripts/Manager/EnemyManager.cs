using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour{
    
    public static EnemyManager Instance;
    
    [SerializeField] private Transform BloodBoss1Page;
    [SerializeField] private GameObject BloodBoss2PagePrefab;
    [SerializeField] ParticleSystem BloodEffect;
    [SerializeField] ParticleSystem BloodEffect1;
    [SerializeField] ParticleSystem BloodEffect2;
    [SerializeField] ParticleSystem BloodEffect3;
    [SerializeField] private float waitTime = 3f;
    public UnityEvent OnDeadEvent;

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
        yield return new WaitForSeconds(1f);
        BloodEffect1.transform.position = new Vector2(BloodBoss1Page.position.x - 2f, BloodBoss1Page.position.y - 2.2f);
        BloodEffect2.transform.position = new Vector2(BloodBoss1Page.position.x, BloodBoss1Page.position.y - 2.2f);
        BloodEffect3.transform.position = new Vector2(BloodBoss1Page.position.x + 2f, BloodBoss1Page.position.y - 2.2f);
        BloodEffect.transform.position = new Vector2(BloodBoss1Page.position.x, BloodBoss1Page.position.y - 1.7f);
        BloodEffect1.Play();
        BloodEffect2.Play();
        BloodEffect3.Play();
        yield return new WaitForSeconds(2f);
        BloodEffect.Play();
        yield return new WaitForSeconds(1f);
        OnDeadEvent?.Invoke();
        BloodBoss2PagePrefab.transform.position = new Vector2(BloodBoss1Page.position.x, BloodBoss1Page.position.y - 0.9f);
        Destroy(BloodBoss1Page.gameObject);
    }
}
