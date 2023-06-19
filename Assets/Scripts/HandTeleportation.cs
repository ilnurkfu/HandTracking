using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class HandTeleportation : MonoBehaviour
{
    [SerializeField] private Transform[] fingersOfTeleportation;
    [SerializeField] private Transform[] fingersOnThePalm;
    [SerializeField] private Transform palm;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform cameraPosition;
    

    [SerializeField] private float requiredDistanceForTheTeleportationFingersOfThePalm;
    [SerializeField] private float requiredDistanceForTheFingersOfThePalm;
    [SerializeField] private float requiredDistanceBetweenFingersAndPalm;
    [SerializeField] private float rayDistance;

    [SerializeField] private bool isPrepareTeleportation;
    [SerializeField] private bool isTeleportation;
    [SerializeField] private bool isLeft;


    [SerializeField] private LineRenderer rayOfFinger;

    [SerializeField] private Gradient defaultColor;
    [SerializeField] private Gradient activateColor;

    private RaycastHit hit;

    [SerializeField] private bool isActivUI;

    [SerializeField] private InteractionHand hand;

    

    private void Awake()
    {
        isLeft = hand.isLeft;
        rayOfFinger = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        TeleportationRay();
        RayColor();
        Teleportation(hit);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivUI == true)
        {
            return;
        }
        if (fingersOfTeleportation.Length > 0)
        {
            for (int i = 0; i < fingersOfTeleportation.Length; i++)
            {
                Vector3 distanceBetweenFingerAndPalm = fingersOfTeleportation[i].position - palm.position;
                if (distanceBetweenFingerAndPalm.sqrMagnitude <
                    requiredDistanceForTheTeleportationFingersOfThePalm *
                    requiredDistanceForTheTeleportationFingersOfThePalm)
                {
                    return;
                }
            }
        }
        if (other != null)
        {
            if (other.GetComponent<Thumb>().isLeft == isLeft)
            {
                if (isPrepareTeleportation == false)
                {
                    isPrepareTeleportation = true;
                }
                else
                {
                    isPrepareTeleportation = false;
                }
            }
        }
    }

    private void TeleportationRay()
    {
        if (hand.isGraspingObject == true)
        {
            isPrepareTeleportation = false;
        }
        if (isPrepareTeleportation == true)
        {
            rayOfFinger.enabled = true;
            if(Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
            {
                Debug.Log(hit.transform.name);
                rayOfFinger.SetPosition(0, transform.position);
                rayOfFinger.SetPosition(1, hit.point);
                if (hit.transform.GetComponent<MeshCollider>())
                {
                    isTeleportation = true;
                }
                else
                {
                    isTeleportation = false;
                }
            }
        }
        else
        {
            rayOfFinger.enabled = false;
            isTeleportation = false;
        }
    }

    private void Teleportation(RaycastHit raycastHit)
    {
        if (isTeleportation == true)
        {
            if (fingersOnThePalm.Length > 1)
            {
                if (palm.gameObject.activeInHierarchy == false)
                {
                    return;
                }
                for (int i = 0; i < fingersOnThePalm.Length - 1; i++)
                {
                    
                    Vector3 distanceBetweenFingerAndPalm = fingersOnThePalm[i].position - palm.position;

                    if (distanceBetweenFingerAndPalm.sqrMagnitude >
                        requiredDistanceBetweenFingersAndPalm * requiredDistanceBetweenFingersAndPalm)
                    {
                        return;
                    }

                    // Vector3 distanceBetweenFingers = fingersOnThePalm[i].position - fingersOnThePalm[i + 1].position;
                    //
                    // if (distanceBetweenFingers.sqrMagnitude >
                    //     requiredDistanceForTheFingersOfThePalm * requiredDistanceForTheFingersOfThePalm)
                    // {
                    //     return;
                    // }
                }
            }

            isPrepareTeleportation = false;
            var nextPosition = playerPosition.parent.position + raycastHit.point -
                               cameraPosition.position;
            nextPosition.y = raycastHit.point.y;
            playerPosition.parent.position = nextPosition;
        }
    }

    private void RayColor()
    {
        if (isTeleportation == true)
        {
            rayOfFinger.colorGradient = activateColor;
        }
        else
        {
            rayOfFinger.colorGradient = defaultColor;
        }
    }

    public void Disable()
    {
        isActivUI = true;
        isPrepareTeleportation = false;
    }

    public void Enable()
    {
        isActivUI = false;
    }
}