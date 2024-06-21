using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public class ShootEnemy : Enemy
{
    [SerializeField]
    private GameObject[] shootList;
    public float x;
    public float y;
    private GameObject shoot;
    private bool hasShot = false;
    private bool changeAnimation = false;
    private string SHOOT_TAG = "shoot";
    private Rigidbody2D myBody;
    private Animator myAnimator;
    private string IDLE_ANIMATION = "sitDown";
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        _Player = GameObject.FindWithTag("Player");
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!hasShot)
        {
            StartCoroutine(AutoShoot());
        }
    }
    IEnumerator AutoShoot()
    {
        hasShot = true;
        changeAnimation = !changeAnimation;
        myAnimator.SetBool(IDLE_ANIMATION, changeAnimation);

        yield return new WaitForSeconds(Random.Range(1, 4));


        shoot = Instantiate(shootList[0]);
        shoot.GetComponent<shoot>().ratioX = x;
        shoot.GetComponent<shoot>().ratioY = y;
        if (changeAnimation)
        {
            shoot.transform.position = new Vector2(transform.position.x + x, transform.position.y + y );
        }
        else
        {
            shoot.transform.position = new Vector2(transform.position.x + x, transform.position.y + y + 0.7f);
        }

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
            }
            //Destroy(collision.gameObject);
        }
    }
}
