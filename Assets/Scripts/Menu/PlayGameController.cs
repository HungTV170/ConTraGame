using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGameController : MonoBehaviour
{
    public void returnMenu()
    {
        Debug.Log("button");
        SceneManager.LoadScene("MainMenu");
    }
}
