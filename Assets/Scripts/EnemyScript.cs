using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemies : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minDistance = 5f;
    private bool isRight = true;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    //Reference other classes
    private PlayerHealth playerHealth;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }

        if(moveDirection.x < 0 && isRight)
        {
            Flip();
        }

        if(moveDirection.x > 0 && !isRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (target && target.position.x < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), moveSpeed * Time.deltaTime);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void Flip()
    {
        isRight = !isRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
