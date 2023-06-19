using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;
using UnityEngine.UI;

public class HandToggle : MonoBehaviour
{
    [SerializeField] private bool isOn;
    [SerializeField] private Image checkmark;

    public bool IsOn
    {
        set { isOn = value; }
    }
    
    [ContextMenu("test")]
    public void SwitchingToggle()
    {
        if (isOn == false)
        {
            isOn = true;
            checkmark.enabled = true;
        }
        else
        {
            isOn = false;
            checkmark.enabled = false;
        }
    }

    [ContextMenu("test2")]
    public void DefaultSettings()
    {
        isOn = false;
        checkmark.enabled = false;
    }

    public void Equaltoggle(bool on)
    {
        isOn = on;
        checkmark.enabled = on;
    }
}
