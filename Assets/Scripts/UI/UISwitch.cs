using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    [SerializeField] private GameObject hand;

    private void Update()
    {
        if (hand.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    
}
