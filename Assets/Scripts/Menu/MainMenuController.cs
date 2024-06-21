using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.DeleteKey("Point");
        PlayerPrefs.DeleteKey("Heal");
        PlayerPrefs.SetFloat("Point", 0);
        PlayerPrefs.SetFloat("Heal", 300);
        SceneManager.LoadScene("GamePlay");
    }
    public void TurialGame()
    {
        SceneManager.LoadScene("TurialMenu");
    }
}
