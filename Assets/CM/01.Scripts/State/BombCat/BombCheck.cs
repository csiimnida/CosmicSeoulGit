using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCheck : MonoBehaviour{
    [SerializeField] private BombCat _cat;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private string _bombName;
    [SerializeField] private Transform _explosionPositon;

    public void Explode(){
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll(transform.position, _cat.explotionRange, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if (player != null && !player.ColCompo.isTrigger)
            {
                player.Damage(_cat.DataSo.AttackPower);
                Debug.Log("데미지 입힘");
            }
        }

        Bomb bomb = PoolManager.Instance.Pop(_bombName) as Bomb;
        bomb.transform.position = _explosionPositon.position;

    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _cat.explotionRange);
    }
}
