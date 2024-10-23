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
    public event Action<EventType> OnClick;

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
            OnClick?.Invoke(EventType.Attack);

    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnClick?.Invoke(EventType.Dash);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnClick.Invoke(EventType.Jump);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        InputVector = context.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(InputVector);
    }

    public void OnSkill1(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnClick?.Invoke(EventType.Skill1);
    }

    public void OnSkill2(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnClick?.Invoke(EventType.Skill2);
    }

    public void OnSpecialSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnClick?.Invoke(EventType.SpecialSkill);
    }
}

public enum EventType
{
    Attack,
    Dash,
    Jump,
    Skill1,
    Skill2,
    SpecialSkill
}
