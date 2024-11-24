using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AwakeSO",menuName = "SO/AwakeSO")]
public class AwakeSO : ScriptableObject
{
 
    public Sprite sprite;
    public string Name = "";
    public float Attack = 0;
    public float speed = 0;
    public float AttackSpeed= 0;
    public float Health = 0;
    public string Text = "";
}
