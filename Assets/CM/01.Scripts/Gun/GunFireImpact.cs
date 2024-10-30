using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireImpact : MonoBehaviour
{
    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    public void FireEffectActive(){
        animator.Play("Skill2Impact");
    }

    private void Update(){
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Skill2Impact") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.Play("Empty");
        }
    }
}
