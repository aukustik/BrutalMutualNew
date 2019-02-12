using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharScript : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D boxcoll;
    BoxCollider2D groundcoll;
    Animator anim;
    float speed = 10f;
    private bool onground = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    State state = State.Idle;
    public bool isFacingRight = true;
    public  LayerMask whatIsGround;
    public GameObject missile;
    public GameObject super_missile;
    private Transform gun;
    public GameObject inventory;
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
        float move;
        onground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", onground);
        anim.SetFloat("vSpeed", rigid.velocity.y);
        if (!onground)
            return;
        move = Input.GetAxis("Horizontal");
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
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(super_missile);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(missile);
        }
        if (onground && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rigid.AddForce(new Vector2(0, 600));
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
