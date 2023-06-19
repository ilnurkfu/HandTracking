using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    private float fps;
    [SerializeField] private Text text;
 
    private void Update()
    {
        fps = 1.0f / Time.deltaTime;
        text.text = "FPS: " + (int)fps;
    }
}
