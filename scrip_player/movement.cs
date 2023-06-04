using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    private InputAction myAction;
    bool double_jump;
    SpriteRenderer spriteRenderer;
    info_player m_info;
    float Horizontal;
    float Vertical;

    float VelocityJump2=10;
    private void Start()
    {
        myAction = new InputAction("myAction", binding: "<keyboard>/space");
        myAction.performed += jum;
        myAction.Enable();
        spriteRenderer = GetComponent<SpriteRenderer>();
        m_info = GetComponent<info_player>();
    }
    private void FixedUpdate()
    {
        //move
        if (m_info.CanMove == true)
        {

            m_info.Rigidbody2D.velocity = new Vector2(Horizontal * m_info.SpeedMove, m_info.Rigidbody2D.velocity.y);
        }
        //climb
        if (m_info.NowClimb)
        {
            m_info.Rigidbody2D.gravityScale = 0f;
            m_info.Rigidbody2D.velocity = new Vector2(m_info.Rigidbody2D.velocity.x, m_info.SpeedClimb * Vertical);
            m_info.CanJump = false;
            m_info.CanCrouch = false;
        }
        else
        {
            m_info.Rigidbody2D.gravityScale = 2f;
            m_info.CanJump = true;
            m_info.CanCrouch = true;
        }
        if (m_info.NowJump == true)
        {
            if (m_info.Rigidbody2D.velocity.y > 0) { m_info.Rigidbody2D.gravityScale = 2f; }
            else if (m_info.Rigidbody2D.velocity.y < 0) { m_info.Rigidbody2D.gravityScale = 3f; }
        }
        if (m_info.Rigidbody2D.velocity.y > VelocityJump2)
            m_info.Rigidbody2D.velocity = new Vector2(m_info.Rigidbody2D.velocity.x, VelocityJump2);
    }
    private void Update()
    {
        //move
        set_flip();
        if (m_info.CanMove == true && Horizontal != 0)
            m_info.NowMove = true;
        else {
            m_info.NowMove = false;
            
        }
        //jump
             
            m_info.NowJump = m_info.CanJump&&m_info.check_ground()==false?true:false;
        if (m_info.check_ground())
            double_jump = true;


        //crouch
        crouch();
        //clim
        if (m_info.CanClimb == false)
        {      
            m_info.NowClimb = false;
        }
        if(m_info.NowCrouch == true) { m_info.Rigidbody2D.velocity = new Vector2(0, m_info.Rigidbody2D.velocity.y); }
        // hit threat
        if (m_info.check_threat())
        {
            
            RaycastHit2D hit= m_info.check_threat();
            if ( hit.collider != null)
            {
                GameObject objectToDestroy = hit.collider.gameObject;
                Destroy(objectToDestroy);
            }
            m_info.Rigidbody2D.AddForce(new Vector2(0,300));
        }
    }
    private void set_flip()
    {       if (Horizontal > 0)
            spriteRenderer.flipX = false;
            else if (Horizontal < 0)
            spriteRenderer.flipX = true;   
    }
    public void move(InputAction.CallbackContext context)
    {
        Horizontal = context.ReadValue<Vector2>().x;
        Vertical = context.ReadValue<Vector2>().y;
    }
   public void jum(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started  &&  Vertical==0 )
        {
            if(m_info.NowJump==false)
            m_info.Rigidbody2D.AddForce(Vector2.up * m_info.VelocityJump, ForceMode2D.Impulse);
            else if (double_jump == true)
            {
                m_info.Rigidbody2D.AddForce(Vector2.up * m_info.VelocityJump, ForceMode2D.Impulse);
                double_jump = false;
            }
            
        }
        
    }
    public void clim(InputAction.CallbackContext context)
    {
        if(Vertical == 1 && context.performed&& m_info.CanClimb)
        {   
            m_info.NowClimb = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("climb"))
        {
            m_info.CanClimb = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("climb"))
        {
            m_info.CanClimb = false;
        }
    }
    void crouch()
    {
        if (m_info.CanCrouch)
        {
            if (Vertical == -1)
            {
                m_info.NowCrouch = true;
                m_info.CanJump = false;
                m_info.CanMove = false;
                m_info.Rigidbody2D.AddForce(new Vector2(0f, -100f));
            }
            else
            {
                m_info.NowCrouch = false;
                m_info.CanMove = true;
                m_info.CanJump = true;
            }

        }
    }
    
}
