using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int lives = 3;
    public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //var magnitude = 1500;

            //var force = transform.position - collision.transform.position;

            //force.Normalize();
            //GetComponent<Rigidbody2D>().AddForce(force * magnitude);
            
            lives -= 1;

            if(lives == 0)
            {
                GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
                GameState.score += 1;
                GameState.remainingAliens -= 1;
                Destroy(effect, 0.5f);
                Destroy(gameObject);
            }
        }
    }


}
