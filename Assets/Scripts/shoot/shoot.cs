using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float moveSpeed = 7.5f; 
    private Rigidbody2D rb;

    public float ratioX;
    public float ratioY;

    public float lifetime = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {


        // Tạo vector lực dựa trên đầu vào
        Vector2 movement = new Vector2(ratioX, ratioY) * moveSpeed;

        // Áp dụng lực vào Rigidbody2D
        rb.velocity = movement;
        Destroy(gameObject, lifetime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }
}
