using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Alient : Enemy
{
    private bool ZombieEnable = true;
    private int option = -1;
    private bool isMove = false;
    public Transform target0;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ZombieEnable)
        {
            StartCoroutine(ZombieController());
        }

    }
    IEnumerator ZombieController()
    {
        ZombieEnable = false;
        option = Random.Range(0, 5);
        switch (option)
        {
            case 0:
                isMove = true;
                yield return MoveToTarget(target0.position);
                break;
            case 1:
                isMove = true;
                yield return MoveToTarget(target1.position);
                break;
            case 2:
                isMove = true;
                yield return MoveToTarget(target2.position);
                break;
            case 3:
                isMove = true;
                yield return MoveToTarget(target3.position);
                break;
            case 4:
                isMove = true;
                yield return MoveToTarget(target4.position);
                break;
        }

        yield return new WaitForSeconds(5f);
    }
    IEnumerator MoveToTarget(Vector3 target)
    {

        while (Vector3.Distance(transform.position, target) > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
            yield return null;
        }

        isMove = false;

        yield return turnOn(4f);
    }
    IEnumerator turnOn(float time)
    {
        yield return new WaitForSeconds(time);
        ZombieEnable = true;

    }
}
