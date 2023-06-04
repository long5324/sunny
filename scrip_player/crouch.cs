using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour
{
    info_player m_info;
    float vertical;
    private void Start()
    {
        m_info = GetComponent<info_player>();
    }
    private void FixedUpdate()
    {
        vertical = Input.GetAxisRaw("Vertical");
        if(m_info.CanCrouch)
        if(vertical == -1)
        {
                m_info.NowCrouch=true;
            m_info.CanMove=false;
            m_info.CanJump=false;
            
            m_info.Rigidbody2D.AddForce(new Vector2(0,2f));
        }
        if(vertical != -1 && m_info.check_ground()) {
            m_info.NowCrouch=false;
            m_info.CanMove=true;
            m_info.CanJump=true;
        }
    }
}
