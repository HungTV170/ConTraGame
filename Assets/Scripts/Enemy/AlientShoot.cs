using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlientShoot : MonoBehaviour
{
    private GameObject item;
    private GameObject shoot;
    private GameObject shoot2;
    private bool hasShot = false;
    private string SHOOT_TAG = "shoot";
    [SerializeField]
    private GameObject[] shootList;
    [SerializeField]
    private GameObject _Player;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.FindWithTag("DropItem");

    }

    // Update is called once per frame
    Vector3 diff;
    void Update()
    {
        //Debug.Log(transform.forward);

        diff = _Player.GetComponent<Transform>().position - transform.position;
        var diffNorm = diff.normalized;
        float rot_z = Mathf.Atan2(diffNorm.y, diffNorm.x) * Mathf.Rad2Deg;
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


        yield return new WaitForSeconds(1f);

        shoot = Instantiate(shootList[0]);
        shoot.GetComponent<shoot>().ratioX = x;
        shoot.GetComponent<shoot>().ratioY = y;

        shoot.transform.position = new Vector2(transform.position.x + 2f, transform.position.y + 2f);

        shoot.GetComponent<shoot>().lifetime = 3f;
        shoot.tag = "Enemy";
        shoot.layer = LayerMask.NameToLayer("EnemyShoot");
 

        shoot2 = Instantiate(shootList[0]);
        shoot2.GetComponent<shoot>().ratioX = x;
        shoot2.GetComponent<shoot>().ratioY = y;

        shoot2.transform.position = new Vector2(transform.position.x - 2f, transform.position.y + 2f);

        shoot2.GetComponent<shoot>().lifetime = 3f;
        shoot2.tag = "Enemy";
        shoot2.layer = LayerMask.NameToLayer("EnemyShoot");
        hasShot = false;

    }
}
