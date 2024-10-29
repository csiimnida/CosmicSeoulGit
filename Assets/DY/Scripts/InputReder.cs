using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputReder : MonoBehaviour
{
    PlayerInput inputs;

    public Action<Vector2> OnMove;
    public Action OnJump;

    private void Start()
    {
        inputs = new PlayerInput();

        inputs.Enable();
        inputs.Player.Jump.performed += Jump;

    }

    private void Update()
    {
        Vector2 input = inputs.Player.Move.ReadValue<Vector2>();

        OnMove?.Invoke(input);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

}
