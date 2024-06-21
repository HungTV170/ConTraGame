using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemy : Enemy
{

    private string SHOOT_TAG = "shoot";
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        _Player = GameObject.FindWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int x;
        if (sr.flipX) { x = 1; }
        else { x = -1; }
        myBody.velocity = new Vector2(x * speed, myBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(SHOOT_TAG))
        {
            heal--;
            if (isDeath())
            {
                Destroy(gameObject);
                getPoint(point);
            }
            //Destroy(collision.gameObject);
        }
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    Destroy(gameObject);
        //    hitPlayer();
        //}
    }
}