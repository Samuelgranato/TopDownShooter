using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    public Sprite updagradedSprite;
    public Sprite normalSprite;
    public int upgrade_time = 5;
    public float upgrade_time_gone = 0f;
    public GameObject weapon;
    public GameObject upgrade_effect;
    public bool upgraded;
    public GameObject slider;
    private Slider slider_comp;

    private void Start()
    {
        slider_comp = slider.GetComponent<Slider>();
    }
    private void Update()
    {
        upgrade_time_gone += Time.deltaTime;

        if (upgraded)
        {
            slider_comp.value = 1 - (upgrade_time_gone / upgrade_time);
        }

        if (upgraded && upgrade_time_gone > upgrade_time)
        {
            weapon.GetComponent<SpriteRenderer>().sprite = normalSprite;
            GetComponent<Shooting>().upgraded = false;
            upgrade_effect.SetActive(false);
            upgraded = false;
            slider_comp.value = 1;
            slider.SetActive(false);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            GetComponent<Shooting>().upgraded = true;
            upgraded = true;
            upgrade_effect.SetActive(true);
            Destroy(collision.gameObject);
            upgrade_time_gone = 0f;
            slider.SetActive(true);


            weapon.GetComponent<SpriteRenderer>().sprite = updagradedSprite;
        }
    }


}
