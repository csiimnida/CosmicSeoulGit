using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [field: SerializeField] public InputReader InputCompo;
    [field: SerializeField] public PlayerDataSO PlayerData;
    
    public AnimationChange AnimCompo {get ; private set;}
    public PlayerRotation RotCompo {get ; private set;}
    public Rigidbody2D RbCompo {get ; private set;}
    public Collider2D ColCompo {get ; private set;}
    
    public SpriteRenderer SpriteCompo {get ; private set;}

    public GroundChecker GroundChecker {get ; private set;}

    private Dictionary<PlayerStateType, PlayerState> StateEnum = new Dictionary<PlayerStateType, PlayerState>();
    private PlayerStateType currentState;
    
    private CinemachineImpulseSource impulseSource;

    public float NowHP { get; private set; }

    private Material NormalMat;
    [SerializeField] private Material HitMat;
    
    public event Action OnDeath;

    private int Exp = 0;
    public UnityEvent<int> OnTakeExp;

    private void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RotCompo = GetComponentInChildren<PlayerRotation>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        GroundChecker = GetComponentInChildren<GroundChecker>();
        SpriteCompo = GetComponentInChildren<SpriteRenderer>();
        impulseSource = GetComponent<CinemachineImpulseSource>();

        NowHP = PlayerData.Hp;
        
        foreach (PlayerStateType stateType in Enum.GetValues(typeof(PlayerStateType)))
        {
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"{enumName}State");
                PlayerState state = Activator.CreateInstance(t, new object[] { this }) as PlayerState;
                StateEnum.Add(stateType, state);

            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        TransitionState(PlayerStateType.Idle);
    }

    private void Start()
    {
        InputCompo.OnMoveEvent += RotCompo.FaceDirection;
        PlayerData.IsFlip = false;
        NormalMat = SpriteCompo.material;
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
    
    public void Damage(EnermyDataSO data, float damage){
        
        if (currentState == PlayerStateType.Block)
        {
            TransitionState(PlayerStateType.BlockImpact);
            return;
        }
        if(currentState == PlayerStateType.Roll) return;
        
        NowHP -= damage;
        if (NowHP > 0)
        {
            SoundManager.Instance.PlaySound("Hurt");
            StartCoroutine(Do_Hit_Effect());
            ShakeCamera(data);
        }
        else if (NowHP <= 0)
        {
            TransitionState(PlayerStateType.Death);
            ShakeCamera(data);
        }
    }
    
    private IEnumerator Do_Hit_Effect()
    {
        SpriteCompo.material = HitMat;
        yield return new WaitForSeconds(0.1f);
        SpriteCompo.material = NormalMat;
    }

    public void GetExp(EnermyDataSO data){
        Exp += data.ExpValue;
        OnTakeExp?.Invoke(Exp);
    }

    public void ResetExp(){
        Exp = 0;
    }

    private void ShakeCamera(EnermyDataSO data){
        impulseSource.m_DefaultVelocity = data.CameraShakePower;
        impulseSource.m_ImpulseDefinition.m_ImpulseDuration = data.CameraShakeDuration;
        impulseSource.GenerateImpulse();
    }

    public void OnDeathEventInvoke(){
        OnDeath?.Invoke();
    }

    private void OnDestroy(){
        InputCompo.OnMoveEvent -= RotCompo.FaceDirection;
        StateEnum[currentState].Exit();
    }

    public float GetHP(){
        return NowHP;
    }
}
