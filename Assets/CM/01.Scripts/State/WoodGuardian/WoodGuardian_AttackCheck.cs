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
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_woodGuardian.attack1Pos.position, _woodGuardian.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_woodGuardian.DataSo,_woodGuardian.DataSo.AttackPower);
        }
    }

    public void Attack2Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_woodGuardian.attack2Pos.position, _woodGuardian.Attack2Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_woodGuardian.DataSo,_woodGuardian.DataSo.AttackPower);
        }
    }
}