using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class info_player : MonoBehaviour
{
   
    // Start is called before the first frame update
    [SerializeField] Vector3 default_position;
    [SerializeField] LayerMask ground_layer;
    [SerializeField] LayerMask climb_layer;
    [SerializeField] LayerMask threat_layer;
    [SerializeField] Transform ground_check;
    private CapsuleCollider2D col;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rg;
    [SerializeField] float speed_climb;
    [SerializeField] float speed_move;
    [SerializeField] float health;
    [SerializeField] float velocity_jump;
    private bool now_jum;
    private bool now_move;
    private bool can_move;
    private bool can_jump;
    private bool can_crouch;
    private bool now_crouch;
    private bool can_climb;
    private bool now_climb;
    private void Start()
    { 
        col = GetComponent<CapsuleCollider2D>();
        rg = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public bool check_ground()
    {
        return Physics2D.CapsuleCast(ground_check.position, new Vector2(0.1f, 0.05f),CapsuleDirection2D.Horizontal,0f,Vector2.down, 0.1f, ground_layer) ;
    }
    public RaycastHit2D check_threat()
    {
        return Physics2D.CapsuleCast(ground_check.position, new Vector2(0.1f, 0.05f), CapsuleDirection2D.Horizontal, 0f, Vector2.down, 0.1f, threat_layer);
    }
    public float SpeedClimb
    {
        get { return speed_climb; }
        set { speed_climb = value; }
    }
   
    public float SpeedMove
    {
        get { return speed_move; }
        set { speed_move = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float VelocityJump
    {
        get { return velocity_jump; }
        set { velocity_jump = value; }
    }

    public bool NowJump
    {
        get { return now_jum; }
        set { now_jum = value; }
    }

    public bool NowMove
    {
        get { return now_move; }
        set { now_move = value; }
    }

    public bool CanMove
    {
        get { return can_move; }
        set { can_move = value; }
    }

    public bool CanJump
    {
        get { return can_jump; }
        set { can_jump = value; }
    }

    public bool CanCrouch
    {
        get { return can_crouch; }
        set { can_crouch = value; }
    }

    public bool NowCrouch
    {
        get { return now_crouch; }
        set { now_crouch = value; }
    }

    public bool CanClimb
    {
        get { return can_climb; }
        set { can_climb = value; }
    }

    public bool NowClimb
    {
        get { return now_climb; }
        set { now_climb = value; }
    }
    public CapsuleCollider2D Collider
    {
        get { return col; }
        set { col = value; }
    }

    public SpriteRenderer Renderer
    {
        get { return spriteRenderer; }
        set { spriteRenderer = value; }
    }

    public Rigidbody2D Rigidbody2D
    {
        get { return rg; }
        set { rg = value; }
    }
}
