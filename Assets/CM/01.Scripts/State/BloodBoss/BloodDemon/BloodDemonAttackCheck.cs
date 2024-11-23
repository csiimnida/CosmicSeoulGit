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
                player.Damage(_bloodDemon);
        }
    }

    public void Attack2Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_bloodDemon.Attack2Pos.position, _bloodDemon.Attack2Size, _layerMask);
        foreach (var collider in colliders)
        {
            print(collider.gameObject.name);
            Player player = collider.GetComponent<Player>();
            if (player != null && !player.ColCompo.isTrigger)
            {
                player.Damage(_bloodDemon);
                if (_bloodDemon.transform.position.x - _bloodDemon.player.transform.position.x >= -2 && _bloodDemon.transform.position.x - _bloodDemon.player.transform.position.x <= 2)  return;
                
                float positionX = _bloodDemon.transform.position.x - _bloodDemon.player.transform.position.x > 0 ? -2 : 2;
                player.transform.position = new Vector2(_bloodDemon.transform.position.x + positionX, player.transform.position.y);
            }
        }
    }
}
