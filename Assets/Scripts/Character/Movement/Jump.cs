using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float velocity; // jump height
    private Rigidbody2D rb;
    private bool canJump; // prevent char unlimited jump in the air 
    Animator animator;

    // Use this for initialization
    void Start()
    {
        velocity = 13f;
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // jump 
        if (!GetComponent<CharController>().isDead) // do not allow player move dead char 
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rb.velocity = Vector2.up * velocity;
                canJump = false;
                animator.SetBool("jump", true);
            }
        }

        // fall faster by increasing gravity 
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 5f * Time.deltaTime;
        }
        // hold button jump higher 
        // if jump button released half way, fall immediatly. 
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when char touch the ground or platform, char can jump again  
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "platform")
        {
            canJump = true;
            animator.SetBool("jump", false);
        }
    }
}
