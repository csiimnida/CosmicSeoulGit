using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enermy : MonoBehaviour
{

    public Player player;
    protected Dictionary<CandyEyeEnermyStateType, EnermyState> StateEnum = new Dictionary<CandyEyeEnermyStateType, EnermyState>();
    public CandyEyeEnermyStateType currentState;
    public EnermyDataSO DataSo;
    public AnimationChange AnimCompo {get ; set;}
    public PlayerRotation RotCompo {get ; set;}
    public Rigidbody2D RbCompo {get ; set;}
    public Collider2D ColCompo {get ;  set;}
    public bool Combit { get; set; }
    public float CombitTimer;

    public SpriteRenderer sprite;

    public float NowHp;
    protected float MaxHp;

    protected Material NomallMaterial;
    public Material HitMaterial;
    

    protected virtual void Awake(){

    }

    protected virtual void Start(){
        player = GameManager.Instance.Player;
    }


    public void TransitionState(CandyEyeEnermyStateType newState)
    {
        StateEnum[currentState].Exit();
        currentState = newState;
        StateEnum[currentState].Enter();
    }

    private void Update()
    {


        CombitTimer += Time.deltaTime;
        if (CombitTimer >= 10)
        {
            Combit = false;
        }
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

    protected virtual void Damage_call(float damage){
        
    }

    public void Damage(float damage) => Damage_call(damage);
}


