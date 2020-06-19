using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public float cameraXOffset = 0f; // Define o deslocamento em X em relação ao personagem
    public float cameraYOffset = 1.0f; // Define o deslocamento em Y em relação ao personagem

    public float horizontalSpeed = 2.0f; // Velocidade que a câmera acompanhará na horizontal
    public float verticalSpeed = 2.0f;   // Velocidade que a câmera acompanhará na vertical

    private Transform cameraTransform;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void Start()
    {
        cameraTransform = Camera.main.transform;

        // Ja posiciona camera a frente do personagem
        cameraTransform.position = new Vector3(
            player.transform.position.x + cameraXOffset,
            player.transform.position.y + cameraYOffset,
            cameraTransform.position.z
        );

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void Update()
    {
        cameraTransform.position = new Vector3(
            Mathf.Lerp(cameraTransform.position.x,
                player.transform.position.x + (cameraXOffset),
                horizontalSpeed * Time.deltaTime),
            Mathf.Lerp(cameraTransform.position.y,
                player.transform.position.y + cameraYOffset,
                verticalSpeed * Time.deltaTime),
            cameraTransform.position.z
        );
    }


    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
