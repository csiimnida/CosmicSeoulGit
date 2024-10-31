using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGuardian_AttackCheck : MonoBehaviour{
    private WoodGuardian _woodGuardian;
    [SerializeField] private LayerMask _layerMask;

    private void Start(){
        _woodGuardian = GetComponentInParent<WoodGuardian>();
    }

    public void Attack1Checker(){
        Collider2D collider =
            Physics2D.OverlapBox(transform.position, _woodGuardian.Attack1Size, _layerMask);
        if (collider != null && collider.CompareTag("Player"))
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
                player.Damage(_woodGuardian.DataSo.AttackPower);
        }
    }

    public void Attack2Checker(){
        Collider2D collider =
            Physics2D.OverlapBox(transform.position, _woodGuardian.Attack2Size, _layerMask);
        if (collider != null && collider.CompareTag("Player"))
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
                player.Damage(_woodGuardian.DataSo.AttackPower);
        }
    }
}