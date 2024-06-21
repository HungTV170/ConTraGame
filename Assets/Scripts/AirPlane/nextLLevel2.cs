using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextLLevel2 : MonoBehaviour
{
    public Vector3 targetPosition; // Vị trí mục tiêu
    public Vector3 target2Position;
    public float speed = 2f; // Tốc độ di chuyển
    public string loadScene;
    private bool active = false;
    private void Update()
    {
        // Di chuyển vật từ từ về vị trí mục tiêu
        GoUp();


    }
    public void GoDown(bool active)
    {
        if(active)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            Debug.Log("Down");
        }

    }
    public void GoUp()
    {
        if (active)
        {
            transform.position = Vector3.Lerp(transform.position, target2Position, Time.deltaTime * speed);
            Debug.Log("Up");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerPropeties>().SavePlayerData();
            collision.gameObject.SetActive(false);
            active = true;
            StartCoroutine(turnOff());
         
        }
    }
    IEnumerator turnOff()
    {

        yield return new WaitForSeconds(2f);
        active = false;
        SceneManager.LoadScene(loadScene);
    }
}
