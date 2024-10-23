
public abstract class State
{
    protected Player _player;

    public State(Player player){
        _player = player;
    }


    public void Enter(){
        _player.InputCompo.OnJumpEvent += HandleJumpPressed;
        _player.InputCompo.OnDashEvent += HandleDashPressed;
        _player.InputCompo.OnAttackEvent += HandleAttackPressed;
        _player.InputCompo.OnSkill1Event += HandleSkill1Pressed;
        _player.InputCompo.OnSkill2Event += HandleSkill2Pressed;
        _player.InputCompo.OnSpecialSkillEvent += HandleSpecialSkillPressed;
        EnterState();
    }

    protected virtual void EnterState()
    {

    }

    public void Exit()
    {
        _player.InputCompo.OnJumpEvent -= HandleJumpPressed;
        _player.InputCompo.OnDashEvent -= HandleDashPressed;
        _player.InputCompo.OnAttackEvent -= HandleAttackPressed;
        _player.InputCompo.OnSkill1Event -= HandleSkill1Pressed;
        _player.InputCompo.OnSkill2Event -= HandleSkill2Pressed;
        _player.InputCompo.OnSpecialSkillEvent -= HandleSpecialSkillPressed;
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
    protected virtual void HandleDashPressed(){
        
    }
    protected virtual void HandleAttackPressed(){
        
    }
    protected virtual void HandleSkill1Pressed(){
        
    }protected virtual void HandleSkill2Pressed(){
        
    }
    protected virtual void HandleSpecialSkillPressed(){
        
    }
}

public enum PlayerStateType
{
    Idle,
    Move,
    Jump,
    Dash,
    Attack,
    Skill1,
    Skill2,
    SpecialSkill
}
