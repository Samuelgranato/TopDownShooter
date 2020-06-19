using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    Vector2 movement;
    public Camera cam;
    Vector2 mouse_pos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mouse_pos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(movement.x * moveSpeed * Time.deltaTime, movement.y * moveSpeed * Time.deltaTime, 0);
        Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);

        Vector2 lookDir = mouse_pos - pos2d;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = (Quaternion.Euler(0, 0, angle));

    }
}
