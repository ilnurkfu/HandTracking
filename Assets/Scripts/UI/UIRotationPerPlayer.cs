using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotationPerPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 direction = (playerPosition.position - transform.position).normalized;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), speed);
    }
}
