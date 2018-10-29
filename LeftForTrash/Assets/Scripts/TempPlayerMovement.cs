using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 movement;
    public float speed = 5.0f;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime);
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }
}
