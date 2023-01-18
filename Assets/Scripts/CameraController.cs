using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player1Movement player1;
    [SerializeField] private Player2Movement player2;


    void Update()
    {
        transform.position = new Vector3((player1.transform.position.x + player2.transform.position.x) / 2,
            (player1.transform.position.y + player2.transform.position.y) / 2, transform.position.z);
    }
}
