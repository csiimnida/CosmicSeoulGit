using JetBrains.Annotations;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Animator AnimatorCompo { get; protected set; }
    public bool IsDead { get; protected set; }
    protected virtual void Awake()
    {
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();
    }
}