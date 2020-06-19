using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    private PlayerLife pl;
    public AudioSource audioSource;
    public AudioClip death;
    private bool died = false;
    // Start is called before the first frame update
    void Start()
    {
        pl = player.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pl.startLives == 0 && !died)
        {
            died = true;
            StartCoroutine(Death());

        }
    }

    IEnumerator Death()
    {
        audioSource.PlayOneShot(death);
        player.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);

    }
}
