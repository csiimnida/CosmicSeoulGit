using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapEnemyColliderCheck : MonoBehaviour{
    private Collider2D _collider;
    [SerializeField] private Vector2 _checkerVectorSize;

    private void Awake(){
        _collider = GetComponentInParent<Collider2D>();
    }

    private void Update(){
        if(Physics2D.OverlapBox(transform.position, _checkerVectorSize, LayerMask.GetMask("Enemy")))
           _collider.isTrigger = true;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, _checkerVectorSize);
    }
}
