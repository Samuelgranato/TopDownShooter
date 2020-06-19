using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class setvolume : MonoBehaviour
{
    public Slider slider;
    private Object[] foundAudioSources;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(slider != null){
            slider.value = GameState.volume;
            slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }
    }

    public void ValueChangeCheck()
    {
        GameState.volume = slider.value;
    }
}
