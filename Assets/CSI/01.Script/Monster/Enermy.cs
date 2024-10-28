using System;
using System.Collections.Generic;
using UnityEngine;
public class Enermy : MonoBehaviour
{

    public GameObject Player;
    private Dictionary<EnermyStateType, EnermyState> StateEnum = new Dictionary<EnermyStateType, EnermyState>();
    private EnermyStateType currentState;
    public EnermyDataSO DataSo;
    public AnimationChange AnimCompo {get ; private set;}
    public PlayerRotation RotCompo {get ; private set;}
    public Rigidbody2D RbCompo {get ; private set;}
    public Collider2D ColCompo {get ; private set;}

    public SpriteRenderer sprite;

    public float NowHp;
    private float MaxHp;
    

    private void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RotCompo = GetComponentInChildren<PlayerRotation>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        MaxHp = DataSo.MaxHp;
        NowHp = MaxHp;
        
        foreach (EnermyStateType stateType in Enum.GetValues(typeof(EnermyStateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"Enermy{enumName}State");
            EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
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


