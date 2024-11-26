using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class Soul_Ghost_EnemyDeadState : EnermyState
{
    public Soul_Ghost_EnemyDeadState(Enemy enemy) : base(enemy)
    {
    }

    protected override void EnterState()
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.ColCompo.enabled = false;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        _emermy.player.GetHpUp();
        _emermy.player.GetExp(_emermy.DataSo);
    }
    public override void UpdateState()
    {
        
    }
}
