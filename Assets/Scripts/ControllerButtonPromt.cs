using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButtonPromt : MonoBehaviour
{
    [SerializeField] private GameObject uI;
    public void Enable()
    {
        uI.SetActive(true);
    }
    
    public void Disable()
    {
        uI.SetActive(false);
    }
}
