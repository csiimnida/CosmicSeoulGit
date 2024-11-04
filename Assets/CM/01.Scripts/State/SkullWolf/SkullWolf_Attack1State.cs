using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullWolf_Attack1State : EnermyState
{
    public SkullWolf_Attack1State(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState()
    {
        _emermy.RbCompo.velocity = Vector2.zero;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Attack1);
        _emermy.RbCompo.AddForce(Vector2.left * 3f, ForceMode2D.Impulse);
    }

    public override void UpdateState()
    {
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x < _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") 
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            if (_emermy.Combit)
            {
                if (_emermy.player.GetComponent<Player>().GetHP() <= 0)
                {
                    _emermy.TransitionState(EnemyStateType.Idle);
                    return;
                }
            }
            _emermy.TransitionState(EnemyStateType.Move);
        }
    }
}
