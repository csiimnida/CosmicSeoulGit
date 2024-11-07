using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDemonAttackCheck : MonoBehaviour
{
    private BloodDemon _bloodDemon;
    [SerializeField] private LayerMask _layerMask;

    private void Start(){
        _bloodDemon = GetComponentInParent<BloodDemon>();
    }

    public void Attack1Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_bloodDemon.Attack1Pos.position, _bloodDemon.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_bloodDemon.DataSo.AttackPower);
        }
    }

    public void Attack2Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_bloodDemon.Attack2Pos.position, _bloodDemon.Attack2Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if (player != null && !player.ColCompo.isTrigger)
            {
                player.Damage(_bloodDemon.DataSo.AttackPower);
                float positionX = (_bloodDemon.transform.position - _bloodDemon.player.transform.position).normalized.x;
                player.RbCompo.AddForce(new Vector2(positionX * 30f, 0), ForceMode2D.Impulse);
            }
        }
    }
}
