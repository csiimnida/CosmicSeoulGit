using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Player _player;

    public State(Player player)
    {
        _player = player;
    }


    public void Enter()
    {
        EnterState();
    }

    protected virtual void EnterState()
    {

    }

    public void Exit()
    {
        ExtiState();
    }

    protected virtual void ExtiState()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void FixedUpdateState()
    {

    }
}

public enum PlayerStateType
{
    Idle,
    Move,
    Jump,
    Dash,
    Attack,
    Skill1,
    Skill2,
    SpecialSkill
}

public enum EnemyStateType
{
    Idle,
    Move,
    Jump,
    Dash,
    Attack,
    Skill1,
    Skill2,
    SpecialSkill
}
