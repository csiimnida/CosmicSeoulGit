using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTrapAttackCheck : MonoBehaviour
{
    private SkeletonTrap _skeletonTrap;
    [SerializeField] private LayerMask _layerMask;

    private void Start(){
        _skeletonTrap = GetComponentInParent<SkeletonTrap>();
    }

    public void Attack1Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_skeletonTrap.attack1Pos.position, _skeletonTrap.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_skeletonTrap.DataSo.AttackPower);
        }
    }
}
