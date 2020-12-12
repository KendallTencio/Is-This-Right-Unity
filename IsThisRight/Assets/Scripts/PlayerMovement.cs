using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    public bool canMove = true;

    void Update()
    {
        if (canMove){
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //-1..1, iz..der
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
                    
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
    }
    public void OnLanding(){
        animator.SetBool("isJumping", false);
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
    }
}
