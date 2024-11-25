using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class Boss_Reaper : Enemy
{
    [field:SerializeField] public Vector2 Attack1Size{ get;private set;}
    [field:SerializeField] public Vector2 TelleportAttackSize{ get;private set;}
    public Transform attack1Pos;
    public Transform telleportAttackPos;
    public UnityEvent ChangePage;
    
    public Playable playbackState;
    protected void Awake()
    {
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        NomallMaterial = sprite.material;

        MaxHp = DataSo.MaxHp;
        NowHp = MaxHp;
        
        foreach (EnemyStateType stateType in Enum.GetValues(typeof(EnemyStateType)))
        {
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"Boss_Reaper_Enemy_{enumName}State");
                EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
                StateEnum.Add(stateType, state);
            }
            catch
            {
                //Debug.Log($"{stateType.ToString()}를 찾을수 없습니다");
            }

        }
        TransitionState(EnemyStateType.Idle);
    }

    protected override void Start(){
        base.Start();
    }

    protected override void Damage_call(float damage){
        if(currentState == EnemyStateType.ChangePage) return;
        NowHp -= damage;
        StartCoroutine(Do_Hit_Effect());
        if (NowHp / MaxHp <= 0.5f && !_now2Page)
        {
            CoolDowning = false;
            _now2Page = true;
            playbackState.Play();
            TransitionState(EnemyStateType.ChangePage);
            ChangePage?.Invoke();
        }
        if (NowHp <= 0)
        {
            print("죽음");
            TransitionState(EnemyStateType.Dead);
            sprite.material = NomallMaterial;
            Destroy(this);
            return;
        }
    }
    

    private void LateUpdate()
    {
        ReqamTimer += Time.deltaTime;
        if (_now2Page && ReqamTimer>=ReqamTimerMax)
        {
            ReqamTimer = 0;
            if (Random.Range(0, 100) <= 30)
            {
                TransitionState(EnemyStateType.BloodRequiem);
            }
        }
    }

    private IEnumerator Do_Hit_Effect()
    {
        sprite.material = HitMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = NomallMaterial;
    }
    public void DoneChangeBackGround()
    {
        TransitionState(EnemyStateType.Move);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,DataSo.Perception_range);//감지 범위
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,DataSo.Attack_range);//공격 범위
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position,SpawnRange);//Spawn 범위
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attack1Pos.position, Attack1Size);// 어택1 범위
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(telleportAttackPos.position, TelleportAttackSize);// 어택2 범위

    }
}
