using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class info_threat : MonoBehaviour

{
    Vector2 defau_position;
    public GameObject player_ ;
    [SerializeField] LayerMask ground_layer;
    [SerializeField] LayerMask player_layer;
    CapsuleCollider2D capsuleCollider;
    [SerializeField] groud_check pl_check;
     Vector2 defautl_position;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D_;
    [SerializeField] private float speedMove;
    [SerializeField] private float limitLeft = 4;
    [SerializeField] private float limitRight = 4;
    [SerializeField] private float timeIdle = 1f;
    [SerializeField] bool can_fl_player=true;
     bool Can_Move = true;
     bool Now_Move;
     bool Now_Idle;
     bool check_hit_ground_right;
     bool check_hit_ground_left;
     bool check_player;
     float raycastDistance;
     float desiredDistance = 0.01f;
    private void Start()
    {
        defautl_position = transform.position;
        player_ = GameObject.Find("player");
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        defautl_position = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D_ = GetComponent<Rigidbody2D>();
        raycastDistance = capsuleCollider.bounds.extents.x + desiredDistance;
    }
    private void Update()
    {
        if(Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, ground_layer))
        check_hit_ground_right = true; 
        else if(Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, ground_layer))
        check_hit_ground_left = true;
        else
        {
            check_hit_ground_left=false;
            check_hit_ground_right=false;
        }
        if(Physics2D.Raycast(defautl_position, Vector2.right, raycastDistance+5f, player_layer)|| Physics2D.Raycast(defautl_position, Vector2.left, raycastDistance + 5f, player_layer))
        {
            check_player = true;
        }
        else { check_player = false; }
    }
    public SpriteRenderer SpriteRenderer
    {
        get { return spriteRenderer; }
        set { spriteRenderer = value; }
    }
    public bool CanFlPlayer
    {
        get { return can_fl_player; }
        set { can_fl_player = value; }
    }
    public Vector2 player
    {
        get { return player_.transform.position; }
    }
    public Rigidbody2D Rigidbody2D
    {
        get { return rigidbody2D_; }
        set { rigidbody2D_ = value; }
    }
    public bool CheckPlayer
    {
        get { return check_player; }
        set { check_player = value; }
    }
    public float SpeedMove
    {
        get { return speedMove; }
        set { speedMove = value; }
    }

    public float LimitLeft
    {
        get { return limitLeft; }
        set { limitLeft = value; }
    }

    public float LimitRight
    {
        get { return limitRight; }
        set { limitRight = value; }
    }

    public float TimeIdle
    {
        get { return timeIdle; }
        set { timeIdle = value; }
    }
    public bool CanMove
    {
        get { return Can_Move; }
        set { Can_Move = value; }
    }

    public bool NowMove
    {
        get { return Now_Move; }
        set { Now_Move = value; }
    }

    public bool NowIdle
    {
        get { return Now_Idle; }
        set { Now_Idle = value; }
    }

    public bool CheckHitGroundRight
    {
        get { return check_hit_ground_right; }
        set { check_hit_ground_right = value; }
    }

    public bool CheckHitGroundLeft
    {
        get { return check_hit_ground_left; }
        set { check_hit_ground_left = value; }
    }
 /*   public groud_check CheckPlayer
    {
        get { return check_player; }
        set { check_player = value; }
    }*/
    public Vector2 DefaultPosition
    {
        get { return defautl_position; }
        set { defautl_position = value; }
    }
}
