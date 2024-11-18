using UnityEngine;

public class SteeringWheelInput : WheelInputSubject
{
    //The boounds set to calculate the normalized input
    [Header("normalization Bounds")]
    public float MaxSteeringValue = 360;
    public float MinSteeringValue = -360;

    //normalized value of the steering wheel
    [Header("Current Output")]
    public float SteeringInput;

    //refrence to the LogitechGSDK's InputManager
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;


    private void Update()
    {
        //update the Information from the wheel and the buttons
        LogitechGSDK.LogiUpdate();

        //returns the state of the controller and stores it in rec
        rec = LogitechGSDK.LogiGetStateUnity(0);

        //gets and sets a normalized value of the steering wheel
        GetWheelInput();
    }

    //gets and sets a normalized value of the steering wheel
    private void GetWheelInput()
    {
        //gets and sends a normalized value of the steering wheel to the observers
        OnWheelInput(NormalizeRawInput(rec.SteeringWheel));
    }


    //Calculates the normalized input of the SteeringWheel
    private float NormalizeRawInput(int rawValue)
    {
        //Calcutation that normalizes the raw input of the pedals
        return Mathf.Lerp(MaxSteeringValue, MinSteeringValue, Mathf.InverseLerp(32767, -32768, rawValue));
    }
}
