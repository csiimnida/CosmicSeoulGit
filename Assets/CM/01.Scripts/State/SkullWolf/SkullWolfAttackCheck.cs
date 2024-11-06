using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullWolfAttackCheck : MonoBehaviour
{
    private SkullWolf _skullWolf;
    [SerializeField] private LayerMask _layerMask;

    private void Start(){
        _skullWolf = GetComponentInParent<SkullWolf>();
    }

    public void Attack1Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y -0.6f), _skullWolf.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_skullWolf.DataSo.AttackPower);
        }
    }
}
