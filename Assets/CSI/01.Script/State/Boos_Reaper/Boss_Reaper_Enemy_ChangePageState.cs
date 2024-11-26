using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class Boss_Reaper_Enemy_ChangePageState : EnermyState
{
    public Boss_Reaper_Enemy_ChangePageState(Enemy enemy) : base(enemy)
    {
    }

    protected override void EnterState()
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.ChangePage);
    }

    public override void UpdateState()
    {
        _emermy.RbCompo.velocity = new Vector2(0, 0);
    }

    
    protected override void ExtiState()
    {
        _emermy.AnimCompo.Animator.runtimeAnimatorController = _emermy._2pageAnim; //너가 만든 배경이 끝났어 그러면 그 스테이트에서 이 코드를 실행 후 Move State로 이동
        _emermy._now2Page = true;
    }
}
