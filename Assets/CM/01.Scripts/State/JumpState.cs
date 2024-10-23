using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public JumpState(Player player) : base(player){
    }

    protected override void EnterState(){
        _player.AnimCompo.PlayAnimaiton(AnimationType.Move);
    }

    public override void UpdateState(){
        
    }
}
