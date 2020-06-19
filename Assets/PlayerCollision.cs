using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class PlayerCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hit;

    private float wait = 1.2f;
    private float wait_blink = 0.1f;
    private float timer = 0;
    private float timer_blink = 0;
    private bool blink_status = true;

    private SpriteRenderer[] spritesrend;

    // Start is called before the first frame update
    void Start()
    {
        spritesrend = GetComponentsInChildren<SpriteRenderer>();
        timer = wait;



}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer_blink += Time.deltaTime;

        if (timer < wait)
        {
            if (timer_blink > wait_blink)
            {
                timer_blink = 0;



                if (blink_status)
                {
                    blink_status = false;
                    foreach (SpriteRenderer rend in spritesrend)
                        rend.enabled = false;
                }
                else
                {
                    blink_status = true;
                    foreach (SpriteRenderer rend in spritesrend)
                        rend.enabled = true;
                }
            }
        }
        else
        {
            foreach (SpriteRenderer rend in spritesrend)
                rend.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && timer > wait)
        {
            timer = 0;
            timer_blink = 0;

            var magnitude = 2000;

            var force = transform.position - collision.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);
            audioSource.PlayOneShot(hit);
            GetComponent<PlayerLife>().startLives -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && timer > wait)
        {
            timer = 0;
            timer_blink = 0;

            var magnitude = 2000;

            var force = transform.position - collision.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);
            audioSource.PlayOneShot(hit);
            GetComponent<PlayerLife>().startLives -= 1;
        }
    }

}
