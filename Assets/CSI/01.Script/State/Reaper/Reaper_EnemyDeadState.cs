using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper_EnemyDeadState : EnermyState
{
    public Reaper_EnemyDeadState(Enemy enemy) : base(enemy)
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
