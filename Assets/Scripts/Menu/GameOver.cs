using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Text textComponent;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Point "+PlayerPrefs.GetFloat("Point"));
        textComponent.text = " YOUR POINT : " + PlayerPrefs.GetFloat("Point").ToString();
    }
    public void returnHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
