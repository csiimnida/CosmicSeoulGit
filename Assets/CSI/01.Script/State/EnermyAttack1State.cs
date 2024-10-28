using UnityEngine;


public class EnermyAttack1State : EnermyState
{
    public EnermyAttack1State(Enermy enermy) : base(enermy)
    {
        
    }
    protected override void EnterState()
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Attack1);
    }

    public override void UpdateState()
    {
        _emermy.transform.localScale = new Vector3(_emermy.transform.position.x > _emermy.Player.transform.position.x ? -1 : 1,_emermy.transform.localScale.y,_emermy.transform.localScale.z);

        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnermyStateType.Move);
        }
    }

    protected override void ExtiState()
    {
        
    }
}
