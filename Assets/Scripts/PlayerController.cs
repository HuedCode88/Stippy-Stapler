using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f; 
    private bool isJumping = false;
    private float timer = 0f;
    private Rigidbody2D rb;         // Reference to the player's Rigidbody component.
    private bool facingRight = true;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    AudioSource sound;
    

    private void Start()
    {
        // Get the Rigidbody component attached to the player GameObject.
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        attackArea = transform.GetChild(1).gameObject;
        sound=gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal");

        //Flip method VVVVVVVV Flip the greater than and less than for future Sprites
        if (horizontalInput > 0 && !facingRight) // Moving right
        {
            Flip();
            
        }
        else if (horizontalInput < 0 && facingRight) // Moving left
        {
            Flip();
        }

        //Flip method^^^^^^^^^^^^

        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        //attacking
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }

        }

        // Check if the player is on the ground and can jump.
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            // Apply an upward force to jump.
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }

        if (horizontalInput > 0f)
        {
            anim.SetBool("walking", true);
        }
        else if (horizontalInput < 0f)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

    }

    // Check for collision with the ground.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        anim.Play("Player_Attack");
        sound.Play();
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}