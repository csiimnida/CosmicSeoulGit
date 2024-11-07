using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodWormDamageCheck : MonoBehaviour
{
    private BloodWorm _bloodWorm;
    [SerializeField] private LayerMask _layerMask;

    private void Start(){
        _bloodWorm = GetComponentInParent<BloodWorm>();
    }

    public void Attack1Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_bloodWorm.Attack1Pos.position, _bloodWorm.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_bloodWorm.DataSo.AttackPower);
        }
    }

    public void Attack2Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_bloodWorm.Attack2Pos.position, _bloodWorm.Attack2Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_bloodWorm.DataSo.AttackPower);
        }
    }
}
