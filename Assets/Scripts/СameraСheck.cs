using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class СameraСheck : MonoBehaviour
{
    [SerializeField] private float rayDistance;

    [SerializeField] private ControllerButtonPromt target;

    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        RaycastShoot();
    }

    private void RaycastShoot()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
        Physics.Raycast(transform.position, transform.forward, out hit, rayDistance);
        if (hit.transform.GetComponent<ControllerButtonPromt>())
        {
            if (target == null)
            {
                target = hit.transform.GetComponent<ControllerButtonPromt>();
                target.Enable();
            }
        }
        else
        {
            if (target != null)
            {
                target.Disable();
                target = null;
            }
        }
    }
}