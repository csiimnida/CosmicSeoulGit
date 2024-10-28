using UnityEngine;


public class EnermyMoveState : EnermyState
{
    public EnermyMoveState(Enermy enermy) : base(enermy)
    {
        
    }

    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Move);
    }

    public override void UpdateState()
    {
        _emermy.transform.localScale = new Vector3(_emermy.transform.position.x > _emermy.Player.transform.position.x ? -1 : 1,_emermy.transform.localScale.y,_emermy.transform.localScale.z);
        
        float positionX = _emermy.Player.transform.position.normalized.x - _emermy.transform.position.normalized.x;
        
        _emermy.RbCompo.velocity = (new Vector2((positionX)*_emermy.DataSo.MoveSpeed,0));
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnermyStateType.Attack1);
        }
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnermyStateType.Idle);
        }
    }

      
}
