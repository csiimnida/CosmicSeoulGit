using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour{

    [SerializeField] private Player _player;
    
    [SerializeField] private Vector2 Attack1Size;
    [SerializeField] private Vector2 Attack2Size;
    [SerializeField] private Vector2 Skill1Size;
    
    [SerializeField] private Transform Attack1Transform;
    [SerializeField] private Transform Attack2Transform;
    [SerializeField] private Transform Skill1Transform;

    private Collider2D Attack1Collider;
    private Collider2D Attack2Collider;
    private Collider2D Skill1Collider;

    public void CheckAttack1(){
        Attack1Collider = Physics2D.OverlapBox(Attack1Transform.position, Attack1Size,0, LayerMask.GetMask("Enemy"));
        if (Attack1Collider != null)
        {
            _player.PlayerData.IsAttack1Hit = true;
        }
    }
    
    public void CheckAttack2(){
        Attack2Collider = Physics2D.OverlapBox(Attack1Transform.position, Attack1Size,0, LayerMask.GetMask("Enemy"));
        if (Attack2Collider != null)
        {
            _player.PlayerData.IsAttack2Hit = true;
        }
    }
    
    public void CheckSkill1(){
        Skill1Collider = Physics2D.OverlapBox(Attack1Transform.position, Attack1Size,0, LayerMask.GetMask("Enemy"));
        if (Skill1Collider != null)
        {
            _player.PlayerData.IsSkill1Hit = true;
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Attack1Transform.position, Attack1Size);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Attack2Transform.position, Attack2Size);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Skill1Transform.position, Skill1Size);
    }
}
