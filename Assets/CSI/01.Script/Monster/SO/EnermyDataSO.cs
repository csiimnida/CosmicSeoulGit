using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enermy/Enermy_Data")]
public class EnermyDataSO : ScriptableObject{
    public int ExpValue;
    
    /// <summary>
    /// 적의 크기를 나타냅니다.
    /// </summary>
    [Header("Enermy Data")]
    public Vector2 Size = new Vector2(1, 1);

    /// <summary>
    /// 적이 공격당 입힐 수 있는 피해량입니다.
    /// </summary>
    public float AttackPower = 1;


    /// <summary>
    /// 적의 최대 생명력을 나타냅니다.
    /// </summary>
    public float MaxHp = 50;

    /// <summary>
    /// 적의 공격 속도를 나타냅니다.
    /// </summary>  
    public float AttackSpeed = 3;

    /// <summary>
    /// 적의 이동 속도를 나타냅니다.
    /// </summary>
    public float MoveSpeed = 3;

    /// <summary>
    /// 적의 감지 범위를 나타냅니다.
    /// </summary>
    public float Perception_range = 10;

    /// <summary>
    /// 적의 공격 범위를 나타냅니다.
    /// </summary>
    public float Attack_range = 5;


    public Vector2 CameraShakePower;
    public float CameraShakeDuration;
    
    /// <summary>
    ///고정형: 이동 기능이 존재하지 않는다.
    ///<para>기습형: 플레이어가 일정 거리 안으로 접근할 때까지 고정형이다가 일정 범위 내로 들어오면 추격 전환</para>
    ///<para>true = 고정형</para>
    ///<para>false = 기습형</para>
    /// </summary>
    [Header("Enermy Attack Type")]
    public bool Anchor_Enermy = false;
    
}
