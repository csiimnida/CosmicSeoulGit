using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Vector2 InputVector { get; private set; }

    public event Action<Vector2> OnMoveEvent;
    public event Action OnJumpEvent;
    public event Action OnDashEvent;
    public event Action OnAttackEvent;
    public event Action OnSkill1Event;
    public event Action OnSkill2Event;
    public event Action OnSpecialSkillEvent;

    private Controls _playerControls;
    private void OnEnable()
    {
        if(_playerControls == null)
        {
            _playerControls = new Controls();
            _playerControls.Player.AddCallbacks(this);
        }
        _playerControls.Player.Enable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnAttackEvent?.Invoke();

    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnDashEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnJumpEvent.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        InputVector = context.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(InputVector);
    }

    public void OnSkill1(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnSkill1Event?.Invoke();
    }

    public void OnSkill2(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnSkill2Event?.Invoke();
    }

    public void OnSpecialSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnSpecialSkillEvent?.Invoke();
    }
}
