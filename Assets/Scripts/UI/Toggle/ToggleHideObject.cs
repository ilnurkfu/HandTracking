using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHideObject : CustomToggle
{
    [SerializeField] private GameObject targetObject;
    private void Awake()
    {
        DefaultSettings();
    }

    public override void Press()
    {
        base.Press();
        Switching();
    }

    public override void DefaultSettings()
    {
        base.DefaultSettings();
        Switching();
    }

    private void Switching()
    {
        if(isOn == true)
        {
            targetObject.SetActive(false);
        }
        else
        {
            targetObject.SetActive(true);
        }
    }
}
