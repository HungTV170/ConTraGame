using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HEAL : MonoBehaviour
{
    private GameObject Player;
    public Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        textComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text =  Player.GetComponent<PlayerPropeties>().heal.ToString();
    }
}
