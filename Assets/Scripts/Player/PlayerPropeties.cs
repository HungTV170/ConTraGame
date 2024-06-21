using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPropeties : MonoBehaviour
{
    public float heal = 100;
    public float point = 0;

    bool isProtect = false;
    bool isExtra = false;
    private float _heal;
    private float _point = 0;

    private string ENEMY_TAG = "Enemy";
    private string ITEM_TAG = "Item";
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerData();
    }
    private void FixedUpdate()
    {
        if(heal < 0)
        {
            SavePlayerData();
            SceneManager.LoadScene("GameOver");
        }
    }
    public void SavePlayerData()
    {
        PlayerPrefs.SetFloat("Point", point);
        PlayerPrefs.SetFloat("Heal", heal);
    }
    private void LoadPlayerData()
    {
        point = PlayerPrefs.GetFloat("Point");
        heal = PlayerPrefs.GetFloat("Heal");
    }
    // Update is called once per frame
    void Update()
    {
        if (isProtect && heal != _heal)
        {
            heal = _heal;
        }

        if (isExtra && point != _point)
        {
            // tăng thêm 1.5 điểm nhận vào
            point += (point - _point) * 0.5f;
            _point = point;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {

            heal--;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ITEM_TAG))
        {
            string effect = collision.gameObject.GetComponent<Item>().effect;
            GetItem(effect);
            Destroy(collision.gameObject);
        }
    }
    private void GetItem(string effet)
    {
        switch (effet)
        {
            case "heal":
                heal += 10;
                break;
            case "point":
                point += 500;
                break;
            case "protect":
                _heal = heal;
                Debug.Log(isProtect);
                StartCoroutine( ActivationProtect(10f) );
                break;
            case "ExtraPoint":
                _point = point;
                StartCoroutine( ActivationExtraPoint(30f) );
                break;
            default:
                return;
        }
    }


    IEnumerator ActivationProtect(float time)
    {
        isProtect = true;
        //Debug.Log(isProtect);

        yield return new WaitForSeconds(time);
        isProtect = false;
    }
    IEnumerator ActivationExtraPoint(float time)
    {
        isExtra = true;
        yield return new WaitForSeconds(time);
        isExtra = false;
    }
}
