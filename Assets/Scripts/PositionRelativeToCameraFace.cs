using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PositionRelativeToCameraFace : MonoBehaviour
{
    [SerializeField] private bool IsFacingCamera;

    [SerializeField] private Transform toFaceCamera;
    [SerializeField] private Camera cameraToFace;

    private bool _initialized = false;

    [SerializeField] private UnityEvent OnBeginFacingCamera;
    [SerializeField] private UnityEvent OnEndFacingCamera;

    [SerializeField] private float minimumValue;
    [SerializeField] private float maximumValue;

    private void Start()
    {
        if (toFaceCamera != null)
        {
            initialize();
        }
    }

    private void initialize()
    {
        if (cameraToFace == null)
        {
            cameraToFace = Camera.main;
        }

        // Set "_isFacingCamera" to be whatever the current state ISN'T, so that we are
        // guaranteed to fire a UnityEvent on the first initialized Update().
        IsFacingCamera = !GetIsFacingCamera(toFaceCamera, cameraToFace, IsFacingCamera ? minimumValue : maximumValue);
        _initialized = true;
    }

    void Update()
    {
            if (toFaceCamera != null && !_initialized)
            {
                initialize();
            }

            if (!_initialized) return;

            if (GetIsFacingCamera(toFaceCamera, cameraToFace, maximumValue) != IsFacingCamera)
            {
                IsFacingCamera = !IsFacingCamera;

                if (IsFacingCamera)
                {
                    OnBeginFacingCamera.Invoke();
                }
                else
                {
                    OnEndFacingCamera.Invoke();
                }
            }
    }

    public static bool GetIsFacingCamera(Transform facingTransform, Camera camera, float minAllowedDotProduct)
    {
        return Vector3.Dot((camera.transform.position - facingTransform.position).normalized, facingTransform.forward) >
               minAllowedDotProduct;
    }
}

