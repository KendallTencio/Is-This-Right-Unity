using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 boxSize = new Vector2(0.1f, 1f);
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    public bool canMove = true;
    public GameObject gameOver;

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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Trampa")
        {
            gameOver.SetActive(true);
            canMove = false;

        }
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
