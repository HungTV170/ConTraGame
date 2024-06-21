using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private string GROUND_TAG = "ground";
    private Rigidbody2D rg;
    public string effect;
    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.CompareTag(GROUND_TAG)){
            Debug.Log("Stop");
            rg.gravityScale = 0;
            rg.velocity = Vector3.zero;
        }
    }
}
