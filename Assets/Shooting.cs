using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bullet_upgradePrefab;
    public bool upgraded = false;

    public float bulletForce = 50f;

    public AudioSource audioSource;
    public AudioClip big;
    public AudioClip small;
    

    public float wait = 0.1f;
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer > wait )
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet;
        if (upgraded)
        {
            wait = 0.5f;
            bullet = Instantiate(bullet_upgradePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(new Vector3(0, 0, 90)));
           // audioSource.pitch = 1.0f;
            audioSource.PlayOneShot(big);
        }
        else
        {
            wait = 0.05f;
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
           //audioSource.pitch = 3.0f;
            audioSource.PlayOneShot(small);

        }
        Rigidbody2D rb_bullet = bullet.GetComponent<Rigidbody2D>();
        rb_bullet.AddForce(firePoint.up * bulletForce , ForceMode2D.Impulse);
    }
}
