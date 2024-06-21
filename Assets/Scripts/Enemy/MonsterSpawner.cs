using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] MonsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    [SerializeField]
    private int side;
    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }
    Vector3 originalScale;
    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3,6));
            randomIndex = Random.Range(0, MonsterReference.Length);
            randomSide = Random.Range(0, side);
            spawnedMonster = Instantiate(MonsterReference[randomIndex]);

            // right side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = new Vector2(rightPos.position.x , rightPos.position.y + Random.Range(1,12)*0.5f);
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(1,4)*0.8f;

            }
            else
            {
                // lefy side
                spawnedMonster.transform.position = new Vector2(leftPos.position.x, leftPos.position.y + Random.Range(1, 12) * 0.5f);
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(1,4);
                originalScale = spawnedMonster.transform.localScale;
                spawnedMonster.transform.localScale = new Vector3(-1f* originalScale.x, 1f* originalScale.y, 1f* originalScale.z);

            }// while loop
        }

    }
}
