using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Datas클래스 수정도 같이 해야함")]
    [Header("Float")]
    public float Damage = 10f;
    public float Skill1Multiple = 2.5f;
    public float Skill2Multiple = 2f;
    public float Hp = 100f;
    public float SwordAttackTime = 1f;
    public float MoveSpeed = 1f;
    public float JumpPower = 4f;
    public float RollPower = 5f;

    public float RollCooltime = 5f;
    public float BlockCooltime = 5f;
    public float Skill1Cooltime = 6f;
    public float Skill2Cooltime = 4f;

    public float BlockingTime = 2f;
    public float currentTime = 0f;

    public float AttackForwardDistance;

    public float CurrentRoolTime;
    public float CurrentBlockTime;
    public float CurrentSkill1Time;
    public float CurrentSkill2Time;

    [Header("Bool")]
    public bool IsGround;

    public bool CanRool = true;
    public bool CanBlock = true;
    public bool CanSkill1 = true;
    public bool CanSkill2 = true;

    public bool IsFlip = false;
}
