using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collision.GetComponent<EnemyHealth>();
            health.TakeDamage(damage);
        }

    }
}
