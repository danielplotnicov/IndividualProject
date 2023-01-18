using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector1 : MonoBehaviour
{
    private int HPpotions = 0;

    [SerializeField] private Text HPpotionsText;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HPpotion"))
        {
            Destroy(col.gameObject);
            HPpotions++;
            HPpotionsText.text = ""+HPpotions;
        }
    }
}
