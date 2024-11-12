using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlimeAttackCheck : MonoBehaviour
{
    private BlueSlime _blueSlime;
    [SerializeField] private LayerMask _layerMask;

    private void Start(){
        _blueSlime = GetComponentInParent<BlueSlime>();
    }

    public void Attack1Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_blueSlime.attack1Pos.position, _blueSlime.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_blueSlime.DataSo,_blueSlime.DataSo.AttackPower);
        }
    }
}
