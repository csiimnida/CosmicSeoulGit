using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Reaper_Enemy_BloodRequiemState : EnermyState
{
    public Boss_Reaper_Enemy_BloodRequiemState(Enemy enemy) : base(enemy)
    {
    }

    protected override void EnterState()
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.BloodRequiem);
        _emermy.BloodRequiemEffect.gameObject.SetActive(true);
        _emermy.SpawnAnimator.enabled = false;
        

    }

    public override void UpdateState()
    {
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("BloodRequiem") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 3f)
        {
            _emermy.TransitionState(EnemyStateType.Idle);
        }
    }

    protected override void ExtiState()
    {
        _emermy.SpawnAnimator.enabled = true;        
        _emermy.BloodRequiemEffect.gameObject.SetActive(false);

    }
}
