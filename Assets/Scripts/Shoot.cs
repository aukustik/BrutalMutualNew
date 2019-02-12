using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    Animator anim;
    BoxCollider2D boxcoll;
    Rigidbody2D rb;
    Rigidbody2D character;
    Vector2 direction;
    Transform gun;
    Transform bulletTr;
    bool BulletFacingRight = true;
    public bool explode = false;
    Vector2 lel = Vector2.left + Vector2.up;
    // Use this for initialization
    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<Transform>();
        character = GameObject.Find("Character").GetComponent<Rigidbody2D>();
        MainCharScript kek = character.gameObject.GetComponent<MainCharScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.position = new Vector2(gun.position.x, gun.position.y);
        gun = GameObject.Find("Gun").GetComponent<Transform>();
        if (kek.isFacingRight)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.rotation = 45f;
                direction = Vector2.right + Vector2.up;
            }
            else
                direction = Vector2.right;
        }

        if (!kek.isFacingRight)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.rotation = 135f;
                direction = Vector2.left + Vector2.up;
            }
            else
                direction = Vector2.left;
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            rb.rotation = 90f;
            direction = Vector2.up;
        }
        
    }


    // Update is called once per frame
    void FixedUpdate ()
    {
        Debug.Log(direction);
        if (!explode)
        {
            
            rb.MovePosition(rb.position += direction * 10 * Time.deltaTime);
            
        }
        if (direction.x > 0 && !BulletFacingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && BulletFacingRight)
        {
            Flip();
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Debug.Log("DESSTROYED~");
    }
    void Explode()
    {
        Destroy(this.gameObject);
        Debug.Log("DESSTROYED~");
    }
    void Stop()
    {
        explode = true;
    }
    private void Flip()
    {
        BulletFacingRight = !BulletFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
