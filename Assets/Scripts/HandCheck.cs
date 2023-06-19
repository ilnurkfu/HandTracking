using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

public class HandCheck : MonoBehaviour
{
    [SerializeField] private HandTeleportation handTeleportation;
    [SerializeField] private InteractionHand hand;
    
    void Update()
    {
        if(hand.isGraspingObject)
        handTeleportation.Disable();
    }
}
