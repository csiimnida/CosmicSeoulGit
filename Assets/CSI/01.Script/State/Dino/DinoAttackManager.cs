using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAttackManager : MonoBehaviour
{
    private Dino _dino;
    [SerializeField] private LayerMask _layerMask;

    private void Start(){
        _dino = GetComponentInParent<Dino>();
    }

    public void Attack1Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_dino.attack1Pos.position, _dino.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_dino);
        }
    }
    public void Attack2Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_dino.attack2Pos.position, _dino.Attack2Size, _layerMask);
        foreach (var collider in colliders)
        {
            print(collider.gameObject.name);
            Player player = collider.GetComponent<Player>();
            if (player != null && !player.ColCompo.isTrigger)
            {
                player.Damage(_dino);
            }
        }
    }
}
