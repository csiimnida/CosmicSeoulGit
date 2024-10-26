using System;
using System.Collections.Generic;
using UnityEngine;
public class Enermy : MonoBehaviour
{

    
    private Dictionary<EnermyStateType, EmermyState> StateEnum = new Dictionary<EnermyStateType, EmermyState>();
    private EnermyStateType currentState;
    public EnermyDataSO DataSo;
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
            Type t = Type.GetType($"Enermy{enumName}State");
            EmermyState state = Activator.CreateInstance(t, new object[] { this }) as EmermyState;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,DataSo.Perception_range);//감지 범위
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,DataSo.Attack_range);//공격 범위
        

    }
}


