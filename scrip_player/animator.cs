using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class animator : MonoBehaviour
{
    [SerializeField] GameObject player;
    Animator player_animator;
    info_player m_info;

    private void Start()
    {
        m_info = player.GetComponent<info_player>();
        player_animator = player.GetComponent<Animator>();
        
    }
    private void LateUpdate()
    {
        run();
        jum();
        crouch();
        clim();
    }
    private void run()
    {
        player_animator.SetBool("is_run",m_info.NowMove);
        // Lấy tham chiếu đến component Animation

        player_animator.SetFloat("speed_run", m_info.SpeedMove);

    }
    void jum()
    {
        player_animator.SetBool("is_jum", m_info.NowJump);
        player_animator.SetFloat("velocityY", m_info.Rigidbody2D.velocity.y);
    }
    void crouch()
    {
       player_animator.SetBool("is_crouch", m_info.NowCrouch? true:false);
    }
    void clim()
    {
        player_animator.SetBool("is_clim", m_info.NowClimb);
        
    }
}
