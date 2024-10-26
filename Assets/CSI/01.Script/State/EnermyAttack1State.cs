

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
        
    }
}
