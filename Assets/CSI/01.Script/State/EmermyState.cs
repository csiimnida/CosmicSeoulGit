using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmermyState : MonoBehaviour
{
    
    /*
    protected EmermyState _emermy;

    public EmermyState(EmermyState player){
        _emermy = player;
    }


    public void Enter(){
        _emermy.InputCompo.OnJumpEvent += HandleJumpPressed;
        _emermy.InputCompo.OnDashEvent += HandleDashPressed;
        _emermy.InputCompo.OnAttackEvent += HandleAttackPressed;
        _emermy.InputCompo.OnSkill1Event += HandleSkill1Pressed;
        _emermy.InputCompo.OnSkill2Event += HandleSkill2Pressed;
        _emermy.InputCompo.OnSpecialSkillEvent += HandleSpecialSkillPressed;
        _emermy.InputCompo.OnMoveEvent += HandleMovement;
        EnterState();
    }

    protected virtual void EnterState()
    {

    }

    public void Exit()
    {
        _emermy.InputCompo.OnDashEvent -= HandleDashPressed;
        _emermy.InputCompo.OnJumpEvent -= HandleJumpPressed;
        _emermy.InputCompo.OnAttackEvent -= HandleAttackPressed;
        _emermy.InputCompo.OnSkill1Event -= HandleSkill1Pressed;
        _emermy.InputCompo.OnSkill2Event -= HandleSkill2Pressed;
        _emermy.InputCompo.OnSpecialSkillEvent -= HandleSpecialSkillPressed;
        _emermy.InputCompo.OnMoveEvent -= HandleMovement;
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
        
    }*/
}
public enum EnermyStateType
{
    Idle,
    Move,
    Jump,
    Dash,
    Attack1,
    Attack2,
    EvAttack,
    Skill1,
    Skill2,
    EvSkill1,
    EvSkill2,
    SpecialSkill
}
