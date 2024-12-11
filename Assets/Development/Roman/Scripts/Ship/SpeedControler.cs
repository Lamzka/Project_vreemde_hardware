using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControler : MonoBehaviour
{
    [SerializeField] private ShipRidgidbodyController ridgidbodyController;
    [SerializeField] private float insideSpeed;
    [SerializeField] private float outsideSpeed;

    private void Start()
    {
        outsideSpeed = ridgidbodyController.maxSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
            ridgidbodyController.maxSpeed = insideSpeed;
    }

    private void OnTriggerExit(Collider other)
    {
        ridgidbodyController.maxSpeed = outsideSpeed;
    }
}
