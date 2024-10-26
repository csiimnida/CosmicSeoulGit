using System;
using System.Collections.Generic;
using UnityEngine;
public class Enermy : MonoBehaviour
{

    private Dictionary<EnermyStateType, State> StateEnum = new Dictionary<EnermyStateType, State>();
    private EnermyStateType currentState;
    
    public AnimationChange AnimCompo {get ; private set;}
    public PlayerRotation RotCompo {get ; private set;}
    public Rigidbody2D RbCompo {get ; private set;}
    public Collider2D ColCompo {get ; private set;}

    private void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RotCompo = GetComponentInChildren<PlayerRotation>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        
        foreach (EnermyStateType stateType in Enum.GetValues(typeof(EnermyStateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"{enumName}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            StateEnum.Add(stateType, state);
        }
        TransitionState(EnermyStateType.Idle);
    }



    public void TransitionState(EnermyStateType newState)
    {
        StateEnum[currentState].Exit();
        currentState = newState;
        StateEnum[currentState].Enter();
    }

    private void Update()
    {
        StateEnum[currentState].UpdateState();
    }

    private void FixedUpdate()
    {
        StateEnum[currentState].FixedUpdateState();
    }
}


public enum EnermyStateType
{
    Idle,
    Move,
    Jump,
    Dash,
    Attack1,
    Attack2,
    EvAttack,
    Skill1,
    Skill2,
    EvSkill1,
    EvSkill2,
    SpecialSkill
}
