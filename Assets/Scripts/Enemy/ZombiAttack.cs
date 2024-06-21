using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ZombiAttack : MonoBehaviour
{
    [SerializeField]
    private Transform leftPos, rightPos;
    [SerializeField]
    private GameObject Rock;
    private GameObject _Rock;
    private GameObject player;
    public GameObject Zombie;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }
    bool RockEnable = true;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RockAttack());
    }
    IEnumerator RockAttack()
    {
        if (Zombie.GetComponent<Zombie>()._isAttack())
        {
            if (RockEnable)
            {
                RockEnable = false;
                yield return Attack();
            }

        }
    }
    IEnumerator Attack()
    {
        Debug.Log("rock");

        for (int j = 0; j <= Random.Range(2, 5); j++)
        {
            yield return new WaitForSeconds(1f);
            _Rock = Instantiate(Rock);

            _Rock.transform.position = new Vector2(
                Random.Range(Mathf.RoundToInt(leftPos.position.x), Mathf.RoundToInt(rightPos.position.x))
                , Random.Range(Mathf.RoundToInt(leftPos.position.y), Mathf.RoundToInt(rightPos.position.y)));
        }
        RockEnable = true;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Zombie.GetComponent<Zombie>()._isMove() )
        {
            player.GetComponent<PlayerPropeties>().heal -= 20;
            player.transform.position = new Vector3(-1.09f, -175f, 0f);
        }

        if (collision.gameObject.CompareTag("shoot"))
        {
            Zombie.GetComponent<Zombie>().heal--;
            if (Zombie.GetComponent<Zombie>().isDeath())
            {
                Zombie.GetComponent<Zombie>().getPoint(Zombie.GetComponent<Zombie>().point);
                Destroy(Zombie);

            }
        }


    }



}
