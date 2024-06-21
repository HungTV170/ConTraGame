using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fortress : MonoBehaviour
{
    private GameObject nextLv;

    // Start is called before the first frame update
    void Start()
    {
        nextLv = GameObject.FindWithTag("NextLV");
    }
    bool active = true;
    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < 1)
        {
            nextLv.gameObject.GetComponent<nextLLevel2>().GoDown(active);
            StartCoroutine(turnOff());
        }
    }

    IEnumerator turnOff() {

        yield return new WaitForSeconds(2f);
        active = false;
    }

}
