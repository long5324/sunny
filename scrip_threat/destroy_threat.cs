using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_threat : MonoBehaviour
{
    [SerializeField] LayerMask player;
    [SerializeField]CapsuleCollider2D cap;
    [SerializeField] GameObject threat; 
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.up, cap.bounds.extents.x + 0.1f, player))
        {
            Destroy(threat);
        }
    }
}
