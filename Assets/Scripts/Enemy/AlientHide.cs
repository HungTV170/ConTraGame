using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlientHide : MonoBehaviour
{
    private bool isHide = false;
    private SpriteRenderer sr;
    public GameObject Alient;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHide)
        {
            StartCoroutine(Hide());
        }
    }

    IEnumerator Hide()
    {
        isHide = true;
        sr.enabled = false;
        yield return new WaitForSeconds(3f);
        sr.enabled = true;
        yield return new WaitForSeconds(10f);
        isHide = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shoot"))
        {
            Alient.GetComponent<Alient>().heal--;
            if (Alient.GetComponent<Alient>().isDeath())
            {
                Alient.GetComponent<Alient>().getPoint(Alient.GetComponent<Alient>().point);
                Destroy(Alient);
            }
        }


    }
}
