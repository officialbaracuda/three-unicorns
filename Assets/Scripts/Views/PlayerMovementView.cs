using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovementView : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    public void Move(Vector3 motion) {
        controller.Move(motion);
    }

    public void Walk()
    {
        animator.SetBool(Constants.IS_WALKING, true);
        animator.SetBool(Constants.IS_JUMPING, false);
    }

    public void StopWalk()
    {
        animator.SetBool(Constants.IS_WALKING, false);
    }

    public void Jump()
    {
        animator.SetBool(Constants.IS_WALKING, false);
        animator.SetBool(Constants.IS_JUMPING, true);
    }

    public void StopJump()
    {
        animator.SetBool(Constants.IS_JUMPING, false);
    }
}
