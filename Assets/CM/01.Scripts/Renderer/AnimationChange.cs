using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationChange : MonoBehaviour
{
    public Animator Animator;
    public UnityEvent OnAnimationAction;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void PlayAnimaiton(AnimationType animationType) 
    {
        switch (animationType)
        {
            case AnimationType.Idle:
                Play("Idle");
                break;
            case AnimationType.Move:
                Play("Move");
                break;
            case AnimationType.Jump:
                Play("Jump");
                break;
            case AnimationType.Fall:
                Play("Fall");
                break;
            case AnimationType.Roll:
                Play("Roll");
                break;
            case AnimationType.Death:
                Play("Death");
                break;
            case AnimationType.Attack1:
                Play("Attack1");
                break;
            case AnimationType.Attack2:
                Play("Attack2");
                break;
            case AnimationType.Skill1:
                Play("Skill1");
                break;
            case AnimationType.Skill2:
                Play("Skill2");
                break;
            case AnimationType.Block:
                Play("Block");
                break;
            case AnimationType.BlockImpact:
                Play("BlockImpact");
                break;
            case AnimationType.Hurt:
                Play("Hurt");
                break;
            default:
                break;
        }
    }

    internal void StopAnimation()
    {
        Animator.enabled = false;
    }
    internal void StartAnimation()
    {
        Animator.enabled = true;
    }

    public void Play(string name)
    {
        Animator.Play(name);
    }

    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }
}

public enum AnimationType
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
