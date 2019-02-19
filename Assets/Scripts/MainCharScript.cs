using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharScript : MonoBehaviour
{
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public bool isFacingRight = true;
    public float jumpForce;
    public  LayerMask whatIsGround;
    public GameObject missile;
    public GameObject super_missile;
    public GameObject inventory;

    Rigidbody2D rigid;
    BoxCollider2D boxcoll;
    BoxCollider2D groundcoll;
    Animator anim;
    State state = State.Idle;
    float speed = 10f;
    bool jumpPressed = false;
    private float move = 0.0f;
    private bool onground = false;
    private Transform gun;
    private bool isGrounded = true;
    private bool OnWall = false;

    // Use this for initialization
    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        boxcoll = GetComponent<BoxCollider2D>();
        groundcoll = GameObject.Find("Background").GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxisRaw("Horizontal");
        anim.SetBool("Ground", onground);
        anim.SetFloat("vSpeed", rigid.velocity.y);
        if (isGrounded && jumpPressed)
        {
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        anim.SetFloat("Speed", Mathf.Abs(move));
        rigid.velocity = new Vector2(move * speed, rigid.velocity.y);
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }
        if (OnWall)
        {
            rigid.AddForce(Vector2.right*move, ForceMode2D.Impulse);
        }
    }
    private void Update()
    {
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(super_missile);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(missile);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            anim.SetBool("OnWall", false);
            OnWall = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        if (collision.gameObject.tag == "Wall")
        {
            anim.SetBool("OnWall", true);
            OnWall = true;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    enum State
    {
        Idle,
        Jump,
        Run
    }
}
