using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName;
    
    [SerializeField] PlayerDataSO _playerData;
    
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed = 5f;
    public string PoolName => _poolName;

    private void Awake(){
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable(){
        if(_playerData.IsFlip)
            _rigidbody2D.AddForce(transform.right * -speed, ForceMode2D.Impulse);
        else
            _rigidbody2D.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem(){
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        Enermy enemy = other.GetComponent<Enermy>();
        if (enemy != null)
        {
            enemy.Damage(_playerData.Damage * _playerData.Skill2Multiple);
        }
        PoolManager.Instance.Push(this);
    }
}