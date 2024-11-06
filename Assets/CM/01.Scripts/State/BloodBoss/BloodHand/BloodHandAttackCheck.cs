using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodHandAttackCheck : MonoBehaviour
{
    private BloodHand _bloodHand;
    [SerializeField] private LayerMask _layerMask;

    private void Start(){
        _bloodHand = GetComponentInParent<BloodHand>();
    }

    public void Attack1Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_bloodHand.attack1Pos.position, _bloodHand.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_bloodHand.DataSo.AttackPower);
        }
    }
}
