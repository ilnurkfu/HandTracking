using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPosition : MonoBehaviour
{
    [SerializeField] private Transform pointPosition;
    [SerializeField] private float shiftInX;
    [SerializeField] private float shiftInZ;

    private void Update()
    {
        transform.position = pointPosition.position + pointPosition.forward * shiftInZ + pointPosition.right * shiftInX ;
    }
}
