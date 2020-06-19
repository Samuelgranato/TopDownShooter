    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadRemaining : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        m_TextComponent.SetText(GameState.remainingAliens.ToString());
    }
}
