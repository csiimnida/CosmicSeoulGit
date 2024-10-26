using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public float Damage = 10f;
    public float Hp = 100f;
    public float SwordAttackTime = 1f;
    public float MoveSpeed = 1f;
    public float JumpPower = 4f;
    public float RollPower = 5f;


    public bool IsGround;
}
