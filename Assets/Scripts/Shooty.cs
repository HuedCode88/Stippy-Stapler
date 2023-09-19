using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Shooty : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float speed;
    public float firingRange = 10;
    private float timer;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance < firingRange)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }
        if (player == null)
        {
            return;
        }
        Chase();
        Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
