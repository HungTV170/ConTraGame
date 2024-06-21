using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurialMenuController : MonoBehaviour
{
    public Sprite[] images; 
    private int currentIndex = 0;
    public Image imageComponent;

    public void ChangeToNextImage()
    {
        
        currentIndex = (currentIndex + 1) % images.Length; 
        imageComponent.sprite = images[currentIndex]; 
    }
    public void ChangeToPrevImage()
    {
        if(currentIndex == 0) { return; }
        currentIndex = (currentIndex - 1) % images.Length;
        imageComponent.sprite = images[currentIndex];
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
