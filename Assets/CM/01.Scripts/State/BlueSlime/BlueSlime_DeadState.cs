using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlime_DeadState : EnermyState
{
    public BlueSlime_DeadState(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.ColCompo.enabled = false;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        _emermy.player.GetHpUp();
        _emermy.player.GetExp(_emermy.DataSo);
    }
}
