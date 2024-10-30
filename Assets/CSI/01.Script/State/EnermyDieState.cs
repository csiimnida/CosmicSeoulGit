using UnityEngine;

public class EnermyDieState : EnermyState
{
    public EnermyDieState(Enermy enermy) : base(enermy)
    {
    }

    protected override void EnterState()
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.ColCompo.enabled = false;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
    }
    public override void UpdateState()
    {
        
    }
}
