using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AwakeSO", menuName = "SO/AwakeDataSO")]
public class AwakeSO : ScriptableObject
{
    public Sprite sprites;
    public List<ParticleSystem> particleSystems;
    public int Attack;
    public int Defende;
    public int AttackAirSpeed;
    public int MoveSpeed;
    public int JumPower;
    public int Skill_1Cooltime;
    public int Skill_2Cooltime;
    public int RollCl;
    public int BlockCl;
    public string Text;
public string Name;

}
