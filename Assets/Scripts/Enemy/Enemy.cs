using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public int heal;
    public float speed;
    public int point;
    public int rateItem;
    public GameObject _Player;
    public Enemy() { }
 
    public Enemy(int heal, float speed, int point, int rateItem)
    {
        this.heal = heal;
        this.speed = speed;
        this.point = point;
        this.rateItem = rateItem;
    }

    public bool isDeath()
    {
        if(heal == 0) return true;
        else return false;
    }

    public void getPoint(int point) 
    {

        _Player.GetComponent<PlayerPropeties>().point += point;
    }
    public void hitPlayer()
    {
        _Player.GetComponent<PlayerPropeties>().heal--;
    }
    public bool getItem()
    {
        int result = Random.Range(1, 101);
        if(result <= rateItem) return true;
        else return false;
    }
}
