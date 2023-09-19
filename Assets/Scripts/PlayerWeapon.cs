using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    private Animator anim;
    [SerializeReference]AudioSource sound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sound= gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
            sound.Play();
        }
    }
    void Shoot()
    {
        anim.Play("Player_Shoot");
        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
    }
}
