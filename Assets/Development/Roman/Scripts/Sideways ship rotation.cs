using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidewaysshiprotation : MonoBehaviour, IButtonInput
{
    [SerializeField] private float minTurnSpeed;
    [SerializeField] private float maxTurnSpeed;

    private Rigidbody rigidbody;

    public float Torque = 0.5f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbody.angularVelocity = Vector3.forward * Mathf.Clamp(rigidbody.angularVelocity.z, minTurnSpeed, maxTurnSpeed);
    }

    public void OnButton(int Button , bool state)
    {
        switch (Button)
        {
            case 4:
                RotateRight();
                break;
            case 5:
                break;
        }
    }

    private void RotateRight()
    {
        rigidbody.AddRelativeTorque(Vector3.up * Torque, ForceMode.Force);
    }
}
