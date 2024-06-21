using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DropItem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemList;
    private GameObject item;
    private int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropNewItem(Vector3 v) 
    {
        randomIndex = Random.Range(0, itemList.Length);
        item = Instantiate(itemList[randomIndex]);
        Vector3 v1 = new Vector3(v.x, v.y + 5f, v.z);
        item.transform.position = v1;

    }
}
