using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hit;
    public AudioClip death;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var magnitude = 1500;

            var force = transform.position - collision.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);
            audioSource.PlayOneShot(hit);
            GetComponent<PlayerLife>().startLives -= 1;
            if (GetComponent<PlayerLife>().startLives == 0)
            {
                audioSource.PlayOneShot(death);
            };
        }
    }
}
