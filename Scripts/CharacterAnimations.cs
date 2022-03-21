using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Walk(bool walk)
    {
        animator.SetBool(AnimationTags.WalkParameter, walk);
    }

    public void Defend(bool defend)
    {
        animator.SetBool(AnimationTags.DefendParameter, defend);
    }

    public void Attack1()
    {
        animator.SetTrigger(AnimationTags.AttackTrigger1);
    }

    public void Attack2()
    {
        animator.SetTrigger(AnimationTags.AttackTrigger2);
    }

    public void Freeze()
    {
        animator.speed = 0f;
    }

    public void unFreeze()
    {
        animator.speed = 1f;
    }
}
