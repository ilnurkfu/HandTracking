using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TurnByHand : MonoBehaviour
{
    // [SerializeField] private Transform cameraTransform;

    [SerializeField] private float angleRotation;

    [SerializeField] private XROrigin xROrigin;
    

    public void TurnLeft()
    {
        xROrigin.RotateAroundCameraUsingOriginUp(-angleRotation);
    }

    public void TurnRight()
    {
        xROrigin.RotateAroundCameraUsingOriginUp(angleRotation);
    }
}
