using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update

    public int startLives = 4;
    public GameObject life_box;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startLives == 4)
        {
            life_box.transform.GetChild(0).gameObject.SetActive(true);
            life_box.transform.GetChild(1).gameObject.SetActive(true);
            life_box.transform.GetChild(2).gameObject.SetActive(true);
            life_box.transform.GetChild(3).gameObject.SetActive(true);
           
        }
        else
        {
            if (startLives == 3)
            {
                life_box.transform.GetChild(0).gameObject.SetActive(true);
                life_box.transform.GetChild(1).gameObject.SetActive(true);
                life_box.transform.GetChild(2).gameObject.SetActive(true);
                life_box.transform.GetChild(3).gameObject.SetActive(false);
                
            }
            else
            {
                if (startLives == 2)
                {
                    life_box.transform.GetChild(0).gameObject.SetActive(true);
                    life_box.transform.GetChild(1).gameObject.SetActive(true);
                    life_box.transform.GetChild(2).gameObject.SetActive(false);
                    life_box.transform.GetChild(3).gameObject.SetActive(false);           
                }
                else
                {
                    if (startLives == 1)
                    {
                        life_box.transform.GetChild(0).gameObject.SetActive(true);
                        life_box.transform.GetChild(1).gameObject.SetActive(false);
                        life_box.transform.GetChild(2).gameObject.SetActive(false);
                        life_box.transform.GetChild(3).gameObject.SetActive(false);                     
                    }
                    else
                    {
                        if (startLives <= 0)
                        {
                            life_box.transform.GetChild(0).gameObject.SetActive(false);
                            life_box.transform.GetChild(1).gameObject.SetActive(false);
                            life_box.transform.GetChild(2).gameObject.SetActive(false);
                            life_box.transform.GetChild(3).gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

}
