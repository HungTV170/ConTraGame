using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowLv2 : CameraFollow
{
    private Transform player;
    private Vector3 temPos;
    [SerializeField]
    private float minY, maxY;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }
    void LateUpdate()
    {
        temPos = transform.position;
        temPos.y = player.transform.position.y;
        if (temPos.y < minY)
        {
            temPos.y = minY;
        }
        if (temPos.y > maxY)
        {
            temPos.y = maxY;
        }

        transform.position = temPos;
    }
}
