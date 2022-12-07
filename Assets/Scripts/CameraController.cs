using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player1Movement player;
    [SerializeField] private int Plater_Camera_Distance = 2;
    void Update()
    {
        if (player.sprite.flipX)
        {
            
            transform.position = new Vector3(player.transform.position.x-Plater_Camera_Distance, player.transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x+Plater_Camera_Distance, player.transform.position.y, transform.position.z);
        }
    }
}
