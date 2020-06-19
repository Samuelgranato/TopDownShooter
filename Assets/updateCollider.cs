using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateCollider : MonoBehaviour
{
    private float changetime = 1f / 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateCollider", 0, changetime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateCollider()
    {
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
