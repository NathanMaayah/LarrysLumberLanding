using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public AudioSource audioSource; // Reference to AudioSource
    public AudioClip jumpSound; // Reference to jump sound clip

    public float runSpeed = 60f;
    float horizontalMove = 0f;
    bool jump = false;
    bool chop = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);
            PlayJumpSound();
        }

//        if(Input.GetButtonDown("Fire1")){
//            chop = true;
//            animator.SetBool("IsChopping", true);
//        }  this was originally my plan for chop but it didnt work out

    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

     void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}


