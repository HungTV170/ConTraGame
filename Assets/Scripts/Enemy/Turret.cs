using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : Enemy
{
    private GameObject item;
    private GameObject shoot;
    private bool hasShot = false;
    private string SHOOT_TAG = "shoot";
    [SerializeField]
    private GameObject[] shootList;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
         item = GameObject.FindWithTag("DropItem");
        _Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    Vector3 diff;
    void Update()
    {
        //Debug.Log(transform.forward);
     
        diff = _Player.transform.position - transform.position;
        var diffNorm = diff.normalized;
        float rot_z = Mathf.Atan2(diffNorm.y, diffNorm.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        x = Mathf.Cos(rot_z * Mathf.Deg2Rad);
        y = Mathf.Sin(rot_z * Mathf.Deg2Rad);
        if (!hasShot)
        {
            StartCoroutine(AutoShoot());
        }
    }

    IEnumerator AutoShoot()
    {
        hasShot = true;


        yield return new WaitForSeconds(Random.Range(1, 4));

        shoot = Instantiate(shootList[0]);
        shoot.GetComponent<shoot>().ratioX = x;
        shoot.GetComponent<shoot>().ratioY = y;

        shoot.transform.position = new Vector2(transform.position.x + x, transform.position.y + y);


        shoot.tag = "Enemy";
        shoot.layer = LayerMask.NameToLayer("EnemyShoot");
        hasShot = false;

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
                if (getItem())
                {
                    item.GetComponent<DropItem>().DropNewItem(transform.position);
                    Debug.Log("Drop Item");
                }
            }
            //Destroy(collision.gameObject);
        }
    }
}
