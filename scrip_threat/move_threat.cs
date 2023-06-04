using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class move_threat : MonoBehaviour
{
    
    float horizontal=1;
    float limit_min,limit_max,speed_default;
    float coundow_timeidel;
    info_threat t_info;
    bool move_left_to_right;
    bool move_right_to_left;
    bool idel;
    private void Start()
    {
        t_info = GetComponent<info_threat>();
        coundow_timeidel = t_info.TimeIdle;
        limit_min = t_info.LimitLeft;
        limit_max=t_info.LimitRight;
        speed_default = t_info.SpeedMove;
    }
    private void FixedUpdate()
    {
        move();
        
    }
    private void Update()
    {
        if (t_info.CheckPlayer&&t_info.CanFlPlayer)
        {
            enemy_folow_player();
        }
        else
        move_default();
        set_flip();
        t_info.NowMove= horizontal ==0?false:true;
    }

    private void move()
    {
        t_info. Rigidbody2D.velocity=( new Vector2(speed_default * horizontal, t_info. Rigidbody2D.velocity.y));
    }
    void move_default()
    {
        if (!idel)
        {
            if ((transform.position.x > t_info.DefaultPosition.x + limit_max||t_info.CheckHitGroundRight)&& horizontal == 1)
            {
                idel = true;
                move_right_to_left = true;
            }
            else if ((transform.position.x < t_info.DefaultPosition.x - limit_min || t_info. CheckHitGroundLeft)&& horizontal == -1)
            {
                idel = true;
                move_left_to_right = true;
            }
        }
        else if(idel==true)
        {
            horizontal = 0;
            coundow_timeidel -= Time.deltaTime;
            if (coundow_timeidel < 0)
            {
                if (move_right_to_left)
                {
                    horizontal = -1;
                    move_right_to_left = false;
                }
                else if (move_left_to_right)
                {
                    horizontal = 1;
                    move_left_to_right = false;
                }
                coundow_timeidel = t_info.TimeIdle;
                idel = false;
            }
           
        }
        
    }
    void enemy_folow_player()
    {
        if (t_info.player.x> transform.position.x)
            horizontal = 1;
        else if (t_info.player.x < transform.position.x) 
            horizontal = -1;
        
    }

    private void set_flip()
    {
        if (horizontal > 0)
        {
            t_info.SpriteRenderer.flipX = true;
        }
        if (horizontal < 0)
        {
            t_info.SpriteRenderer.flipX = false;
        }
    }
}
