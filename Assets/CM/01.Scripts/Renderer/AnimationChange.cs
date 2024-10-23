using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationChange : MonoBehaviour
{
    private Animator _animator;
    public UnityEvent OnAnimationAction;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimaiton(AnimationType animationType) 
    {
        switch (animationType)
        {
            case AnimationType.Idle:
                Play("Idle");
                break;
            case AnimationType.Move:
                Play("Run");
                break;
            case AnimationType.Jump:
                Play("Jump");
                break;
            case AnimationType.Fall:
                Play("Fall");
                break;
            case AnimationType.Dash:
                Play("Dash");
                break;
            case AnimationType.Die:
                Play("Die");
                break;
            case AnimationType.Attack1:
                Play("Attack1");
                break;
            case AnimationType.Attack2:
                Play("Attack2");
                break;
            case AnimationType.EvAttack:
                Play("EvAttack");
                break;
            case AnimationType.Skill1:
                Play("Skill1");
                break;
            case AnimationType.Skill2:
                Play("Skill2");
                break;
            case AnimationType.EvSkill1:
                Play("EvSkill1");
                break;
            case AnimationType.EvSkill2:
                Play("EvSkill2");
                break;
            default:
                break;
        }
    }

    internal void StopAnimation()
    {
        _animator.enabled = false;
    }
    internal void StartAnimation()
    {
        _animator.enabled = true;
    }

    public void Play(string name)
    {
        _animator.Play(name);
    }

    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }
}

public enum AnimationType
{
    Idle,
    Dash,
    Die,
    Attack1,
    Attack2,
    EvAttack,
    Move,
    Jump,
    Fall,
    Skill1,
    Skill2,
    EvSkill1,
    EvSkill2
}
