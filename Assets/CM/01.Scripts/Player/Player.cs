using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public InputReader InputCompo;
    [field: SerializeField] public PlayerDataSO PlayerData;
    
    public AnimationChange AnimCompo {get ; private set;}
    public PlayerRotation RotCompo {get ; private set;}
    public Rigidbody2D RbCompo {get ; private set;}
    public Collider2D ColCompo {get ; private set;}

    public GroundChecker GroundChecker {get ; private set;}

    private Dictionary<PlayerStateType, PlayerState> StateEnum = new Dictionary<PlayerStateType, PlayerState>();
    private PlayerStateType currentState;

    private float NowHP;
    
    public event Action OnDeath;


    private void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RotCompo = GetComponentInChildren<PlayerRotation>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        GroundChecker = GetComponentInChildren<GroundChecker>();

        NowHP = PlayerData.Hp;
        
        foreach (PlayerStateType stateType in Enum.GetValues(typeof(PlayerStateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"{enumName}State");
            PlayerState state = Activator.CreateInstance(t, new object[] { this }) as PlayerState;
            StateEnum.Add(stateType, state);
        }
        TransitionState(PlayerStateType.Idle);
    }

    private void Start()
    {
        InputCompo.OnMoveEvent += RotCompo.FaceDirection;
        PlayerData.IsFlip = false;
    }

    public void TransitionState(PlayerStateType newState){
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

    public void Damage(float damage){
        NowHP -= damage;

        if (currentState == PlayerStateType.Block)
        {
            NowHP += damage;
            TransitionState(PlayerStateType.BlockImpact);
        }
        else if(NowHP > 0)
            TransitionState(PlayerStateType.Hurt);
        else if(NowHP <= 0)
            TransitionState(PlayerStateType.Death);
    }

    public void OnDeathEventInvoke(){
        OnDeath?.Invoke();
    }

    private void OnDestroy(){
        StateEnum[currentState].Exit();
    }

    public float GetHP(){
        return NowHP;
    }
}
