using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator anim;
    GameObject portalleft;
    Rigidbody2D rb;
    CircleCollider2D cc;
    bool moving = true;
    private float hp = 4.0f;
	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        portalleft = GameObject.Find("PortalLeft");
        Debug.Log(portalleft.transform.position);
        rb.position = new Vector2(portalleft.transform.position.x, portalleft.transform.position.y);
	}
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            rb.MovePosition(rb.position += Vector2.right * 2 * Time.deltaTime);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(collision, 1.0f);
            
        }
        if (collision.gameObject.tag == "SuperBullet")
        {
            Animator animat = collision.gameObject.GetComponent<Animator>();
            animat.SetFloat("Explode", -2);
            TakeDamage(collision, 50.0f);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void Explode()
    {
        moving = false;
        anim.SetBool("Death", true);
    }
    void Death()
    {
        Destroy(this.gameObject);
    }
    void TakeDamage(Collider2D coll, float damage)
    {
        Animator animat = coll.gameObject.GetComponent<Animator>();
        animat.SetFloat("Explode", 3);
        hp -= damage;
        if (hp <= 0)
        {
            rb.gravityScale = 0;
            cc.enabled = false;
            anim.SetBool("Moving", false);
            Explode();
            
        }
    }
    void InDaSky()
    {
        rb.AddForce(Vector2.up * 300, ForceMode2D.Force);
    }
}
