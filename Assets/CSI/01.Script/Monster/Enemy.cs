using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Player player;
    protected Dictionary<EnemyStateType, EnermyState> StateEnum = new Dictionary<EnemyStateType, EnermyState>();
    public EnemyStateType currentState{ get; private set; }
    protected EnemyStateType previousState{ get; set; }
    public EnemyStateType nextState{ get; set; }
    public EnermyDataSO DataSo;
    public AnimationChange AnimCompo {get ; set;}
    public Rigidbody2D RbCompo {get ; set;}
    public Collider2D ColCompo {get ;  set;}
    public bool Combit { get; set; }
    public float CombitTimer;

    public float CoolTimeMaxTimer;
    public float CoolTimeNowTimer;

    public SpriteRenderer sprite;
    public bool CoolDowning;

    protected float NowHp;
    protected float MaxHp;
    public float SpawnRange = 5f;

    protected Material NomallMaterial;
    public Material HitMaterial;
    

    protected virtual void Awake(){

    }

    protected virtual void Start(){
        player = GameManager.Instance.Player;
        CoolTimeMaxTimer = DataSo.AttackSpeed;
    }


    public void TransitionState(EnemyStateType newState)
    {
        StateEnum[currentState].Exit();
        previousState = currentState;
        currentState = newState;
        StateEnum[currentState].Enter();
    }

    private void Update()
    {
        CombitTimer += Time.deltaTime;
        if (CombitTimer >= 10)////////////////////////////CombitTimer 수정 요함
        {
            Combit = false;
        }

        if (CoolTimeNowTimer < 10 + CoolTimeMaxTimer && CoolDowning)
        {
            if (CoolTimeNowTimer >= CoolTimeMaxTimer)
            {
                CoolDowning = false;
                TransitionState(nextState);
                return;
            }
                
            CoolTimeNowTimer += Time.deltaTime;
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
    Avoid,
    Attack1,
    Attack2,
    Attack3,
    Dead,
    Spawn,
    Empty
}