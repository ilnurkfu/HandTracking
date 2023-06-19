using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color notBasecolor;
    [SerializeField] private Image fillColor; 
    
    public void BaseColor()
    {
        fillColor.color = baseColor;
    }

    public void NotBaseColor()
    {
        fillColor.color = notBasecolor;
    }      

}
