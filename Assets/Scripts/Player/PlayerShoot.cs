using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject[] shootList;
    private GameObject shoot;
    private bool hasShot = false; // Cờ để kiểm tra đã tạo ra "shoot" trong frame hiện tại hay chưa
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = 1;float y;
        if (Input.GetKey(KeyCode.W))
        {
            y = 1;
        }
        else if (Input.GetKey(KeyCode.S)){
            y = -1;
        }
        else
        {
            y = 0;
        }
        if (sr.flipX) { x = -1; }
        else { x = 1; }


        if (!hasShot && Input.GetKey(KeyCode.J))
        {
            
            shoot = Instantiate(shootList[0]);
            shoot.GetComponent<shoot>().ratioX = x;
            shoot.GetComponent<shoot>().ratioY = y;
            shoot.transform.position = new Vector2(transform.position.x+x, transform.position.y+y+1f);
            hasShot = true; 
        }
        else if (!Input.GetKey(KeyCode.J))
        {
            hasShot = false; 
        }
    }
}

