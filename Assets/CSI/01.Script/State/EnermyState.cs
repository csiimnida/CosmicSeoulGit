
using UnityEngine;

public class EnermyState
{

    protected Enermy _emermy;

    public EnermyState(Enermy enermy){
        _emermy = enermy;
    }


    public void Enter(){

        EnterState();
    }

    protected virtual void EnterState()
    {

    }

    public void Exit()
    {

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

    protected virtual void HandleMovement(Vector2 vector){
        
    }
}
public enum EnermyStateType
{
    Idle,
    Move,
    Attack1,
    Die,
}