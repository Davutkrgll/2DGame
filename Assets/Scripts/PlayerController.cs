using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using Unity.VisualScripting;
using System;

public class PlayerController : MonoBehaviour
{ 
    public Controller controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;


    private bool canDash = true;
    private bool isDashing;
    private float DashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] TrailRenderer tr;
     [SerializeField] Rigidbody2D rb;



    
   
    // Update is called once per frame
    void Update()
    { 
      
      if (isDashing)
      {
        return;
      }
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       if (Input.GetButtonDown("Jump"))
       {
        jump = true;
        animator.SetBool("IsJumping",true);
        
        }


        if (Input.GetButtonDown("Crouch"))
        {
          crouch = true;
        }

        else if(Input.GetButtonUp("Crouch")){
          crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)&& canDash)
        {
          StartCoroutine(Dash());
        }
        
    }
    public void OnLanding(){
      animator.SetBool("IsJumping" ,false);

    }
      void FixedUpdate() {
        if (isDashing)
        {
          return;
        }
        controller.Move(horizontalMove* Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
    private IEnumerator Dash(){
      canDash = false;
      isDashing = true;
      float orginalGravitiy =rb.gravityScale;
      rb.gravityScale = 0f;
      rb.linearVelocity = new Vector2(transform.localScale.x * DashingPower,0f);
      tr.emitting = true;
      yield return new WaitForSeconds(dashingTime);
      tr.emitting = false;
      rb.gravityScale = orginalGravitiy;
      isDashing = false;
      yield return new WaitForSeconds(dashingCooldown);
      canDash =true;
      
    }


    
    }

