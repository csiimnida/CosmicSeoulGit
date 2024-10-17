using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Agent
{
    public PlayerStateMachine stateMachine;
    public bool CanStateChangeable { get; private set; } = true;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
    }
}
