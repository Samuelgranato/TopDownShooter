using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getvolume : MonoBehaviour
{
    float initialvolume;
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        initialvolume = GetComponent<AudioSource>().volume;
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = initialvolume * GameState.volume;
    }

    // Update is called once per frame
    void Update()
    {
        audiosource.volume = initialvolume * GameState.volume;
    }
}
