using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_threat : MonoBehaviour
{
    Animator threat_animator;
    info_threat threat;
    private void Start()
    {
        threat=GetComponent<info_threat>();
        threat_animator = GetComponent<Animator>();
    }
    private void Update()
    {
        threat_animator.SetBool("is_move",threat.NowMove?true:false);

    }
}
