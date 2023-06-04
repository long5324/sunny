using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class groud_check : MonoBehaviour
{
    public bool check_player;
     CapsuleCollider2D capsule;
    private void Start()
    {
        capsule = GetComponent<CapsuleCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            check_player = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            check_player   = false;
            
        }
    }
    public void set_size(float a, float b)
    {
        capsule.size= new Vector2(a,b);
    }
}
