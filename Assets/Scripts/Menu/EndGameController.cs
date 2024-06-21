using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textComponent;
    public Text highestPlayer;
    public Text highestScore;
    public InputField playerNameField;
    private string Name = " you are the best warrior";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = PlayerPrefs.GetFloat("Point").ToString();
        if (PlayerPrefs.GetFloat("SCORE").ToString() == null || PlayerPrefs.GetFloat("SCORE") <= PlayerPrefs.GetFloat("Point"))
        {
            PlayerPrefs.SetString("WARRIOR", Name);
            Debug.Log(PlayerPrefs.GetString("WARRIOR"));
            PlayerPrefs.SetFloat("SCORE", PlayerPrefs.GetFloat("Point"));
        }
        highestPlayer.text = " BEST WARRIOR : " + PlayerPrefs.GetString("WARRIOR");
        highestScore.text = " BEST SCORE : " + PlayerPrefs.GetFloat("SCORE").ToString();

    }
    public void returnHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void playAgain()
    {
        PlayerPrefs.DeleteKey("Point");
        PlayerPrefs.DeleteKey("Heal");
        PlayerPrefs.SetFloat("Point", 0);
        PlayerPrefs.SetFloat("Heal", 300);
        SceneManager.LoadScene("GamePlay");
    }
    public void OnNameSubmit()
    {
        Name = playerNameField.text;
    }
}