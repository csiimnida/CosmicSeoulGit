using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName;
    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;
    
    private Animator _animator;

    private void Awake(){
        _animator = GetComponent<Animator>();
    }

    public void ResetItem(){
        
    }

    private void Update(){
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            PoolManager.Instance.Push(this);
    }
}
