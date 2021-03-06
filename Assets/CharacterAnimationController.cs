using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private readonly int FORWARD_VELOCITY = Animator.StringToHash("ForwardVelocity");
    private readonly int SIDE_VELOCITY = Animator.StringToHash("SideVelocity");
    
    
    public void SetForwardVelocity(float value)
    {
        animator.SetFloat(FORWARD_VELOCITY, value);
    }
    
    public void SetSideVelocity(float value)
    {
        animator.SetFloat(SIDE_VELOCITY, value);
    }
}
