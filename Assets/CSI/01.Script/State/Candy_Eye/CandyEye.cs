using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyEye : Enermy
{
    protected override void Awake(){
        base.Awake();
    }

    protected override void Start(){
        base.Start();
    }
}
public enum CandyEyeEnermyStateType
{
    Idle,
    Move,
    Attack1,
    Die,
}
