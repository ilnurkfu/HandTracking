using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CustomToggle : MonoBehaviour
{
    [SerializeField] protected bool isOn;
    [SerializeField] protected Image checkMark;

    public virtual void DefaultSettings()
    {
        isOn = false;
        checkMark.enabled = false;
    }

    public virtual void Press()
    {
        isOn = !isOn;
        checkMark.enabled = !checkMark.enabled;
    }
    
}
