using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public Player player;
    protected Dictionary<EnemyStateType, EnermyState> StateEnum = new Dictionary<EnemyStateType, EnermyState>();
    public EnemyStateType currentState;
    public EnermyDataSO DataSo;
    public AnimationChange AnimCompo {get ; set;}
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


    public void TransitionState(EnemyStateType newState)
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

    

    protected virtual void Damage_call(float damage){
        
    }

    public void Damage(float damage) => Damage_call(damage);
}

public enum EnemyStateType
{
    Idle,
    Move,
    Attack1,
    Attack2,
    Attack3,
    Dead,

    Die,
}
