using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPedalNormalizing : MonoBehaviour
{
    public float PedalRawMinValue = 32767;
    public float PedalRawMaxValue = -32768;

    public float PedalMinValue = 0;
    public float PedalMaxValue = 100;

    public float GasPedalInput;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

    private void Update()
    {
        GetGasInput();
    }

    private void FixedUpdate()
    {
        MoveShip();
    }

    private void GetGasInput()
    {
        float RawInput;
        RawInput = rec.Gaspedal;
        GasPedalInput = Mathf.Lerp( PedalMinValue, PedalMaxValue, Mathf.InverseLerp(PedalRawMinValue, PedalRawMaxValue, RawInput) );
    }

    private void MoveShip()
    {
        rb.AddForce((transform.forward * GasPedalInput), ForceMode.Impulse);
    }
}
