using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullWolf_DeadState : EnermyState
{
    public SkullWolf_DeadState(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.ColCompo.enabled = false;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
    }
}
