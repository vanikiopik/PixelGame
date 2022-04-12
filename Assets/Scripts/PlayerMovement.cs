using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    // Fields for isGrounded method
    public bool isGrounded;
    public Transform groundCheck;
    private float _checkRadius = 0.6f;
    public LayerMask whatIsGround;

    // Fields for double-jumps
    public int allowJumps;
    private int _jumpCount = 2;

    //For jumps cooldown 
    private float _timeJump;
    [SerializeField]
    private float _jumpCooldownTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();    
        animator = GetComponent<Animator>();
        _jumpCount = 0;
    }


    void Move()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.Play("Idle");
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(1f, rb.velocity.y);
            Gap(1);             
            animator.Play("Run");
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-1f, rb.velocity.y);
            Gap(-1);
            animator.Play("Run");
        }
    }


    public void FlipY(bool isLeft)
    {
        sr.flipX = isLeft;
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // First jump
            if (isGrounded)
            {
                rb.velocity = new Vector2(0f, 4f);
            }
            // Second jump
            else if (_jumpCount < allowJumps - 1)
            {
                rb.velocity = new Vector2(0f, 4f);
                _jumpCount++;
            }
        }
    }


    //Telepors player, int dir need to choose the direction of teleporting
    //NEED TO FIX TELEPORTING INTO WALLS
    void Gap(int dir)
    {
        if (_timeJump <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transform.position += new Vector3(dir, 0f, 0f);
                _timeJump = _jumpCooldownTime;
            }
        }
        else
        {
            _timeJump -= Time.deltaTime;
        }
    }


    void Update()
    {
        Move();
        Jump();
        //Gap();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Debug.Log("Damage");
        }
    }*/

    void FixedUpdate()
    {
        //State for checking object collision on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, _checkRadius, whatIsGround);
        if (isGrounded)
        {
            _jumpCount = 0;
        }
    }
}
