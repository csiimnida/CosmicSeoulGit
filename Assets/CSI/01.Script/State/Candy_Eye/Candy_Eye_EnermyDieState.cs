using UnityEngine;

public class Candy_Eye_EnermyDieState : EnermyState
{
    public Candy_Eye_EnermyDieState(Enemy enemy) : base(enemy)
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
