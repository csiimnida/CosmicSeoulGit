using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino_DeadState : EnermyState
{
    public Dino_DeadState(Enemy enemy) : base(enemy)
    {
    }
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.ColCompo.enabled = false;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        _emermy.player.GetHpUp();
        _emermy.DeadEventInvokeMethod();
        _emermy.player.GetExp(_emermy.DataSo);
    }
}
