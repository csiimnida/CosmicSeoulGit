using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullWolf_DeadState : EnermyState
{
    public SkullWolf_DeadState(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.ColCompo.enabled = false;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        _emermy.player.GetHp();
        _emermy.player.GetExp(_emermy.DataSo);
    }
}
