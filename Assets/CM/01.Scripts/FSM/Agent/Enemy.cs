using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Agent
{
    public bool CanStateChangeable { get; protected set; } = true;
    protected override void Awake()
    {
        base.Awake();
    }
}
