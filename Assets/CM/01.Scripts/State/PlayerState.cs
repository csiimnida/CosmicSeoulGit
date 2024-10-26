using UnityEngine;

public abstract class PlayerState
{
    protected Player _player;

    public PlayerState(Player player){
        _player = player;
    }


    public void Enter(){
        _player.InputCompo.OnJumpEvent += HandleJumpPressed;
        _player.InputCompo.OnDashEvent += HandleRollPressed;
        _player.InputCompo.OnAttackEvent += HandleAttackPressed;
        _player.InputCompo.OnSkill1Event += HandleSkill1Pressed;
        _player.InputCompo.OnSkill2Event += HandleSkill2Pressed;
        _player.InputCompo.OnMoveEvent += HandleMovement;
        EnterState();
    }

    protected virtual void EnterState()
    {

    }

    public void Exit()
    {
        _player.InputCompo.OnJumpEvent -= HandleJumpPressed;
        _player.InputCompo.OnDashEvent -= HandleRollPressed;
        _player.InputCompo.OnAttackEvent -= HandleAttackPressed;
        _player.InputCompo.OnSkill1Event -= HandleSkill1Pressed;
        _player.InputCompo.OnSkill2Event -= HandleSkill2Pressed;
        _player.InputCompo.OnMoveEvent -= HandleMovement;
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

    protected virtual void HandleJumpPressed(){
        
    }
    protected virtual void HandleRollPressed(){
        
    }
    protected virtual void HandleAttackPressed(){
        
    }
    protected virtual void HandleSkill1Pressed(){
        
    }protected virtual void HandleSkill2Pressed(){
        
    }
    protected virtual void HandleSpecialSkillPressed(){
        
    }

    protected virtual void HandleMovement(Vector2 vector){
        
    }
}

public enum PlayerStateType
{
    Idle,
    Move,
    Jump,
    Fall,
    Roll,
    Hurt,
    Death,
    Attack1,
    Attack2,
    Skill1,
    Skill2,
    Block,
    BlockImpact
}
