using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if(enemy != null)
        {
            enemy.TakeDamage(1);
        }
        Destroy(gameObject);
    }



}
