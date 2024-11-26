using CSI._01.Script.Monster;
using UnityEngine;

public class SkeletonTrap_EmptyState : EnermyState
{
    public SkeletonTrap_EmptyState(Enemy enemy) : base(enemy){
    }

    public override void UpdateState(){
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.SpawnRange, LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnemyStateType.Spawn);
        }
    }
}
