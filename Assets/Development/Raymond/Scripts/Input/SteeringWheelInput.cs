using UnityEngine;

public class SteeringWheelInput : MonoBehaviour
{




    public float MaxSteeringValue = 360;
    public float MinSteeringValue = -360;

    private LogitechGSDK.DIJOYSTATE2ENGINES rec;
    public LogitechGSDK.LogiControllerPropertiesData properties;

    //SteeringWheel
    public float steeringInput;

    //Pedals
    public float gasPedalInput;
    public float brakePedalInput;
    /*private int ClutchPedalInput[];*/



    public void Start()
    {
        Debug.Log("SteeringInit:" + LogitechGSDK.LogiSteeringInitialize(false));

    }
    private void Update()
    {
        LogitechGSDK.LogiUpdate();

        rec = LogitechGSDK.LogiGetStateUnity(0);

        LogitechGSDK.LogiControllerPropertiesData actualProperties = new LogitechGSDK.LogiControllerPropertiesData();
        LogitechGSDK.LogiGetCurrentControllerProperties(0, ref actualProperties);

        GetWheelInput();




    }


    void GetWheelInput()
    {
        float RawInput;
        RawInput = rec.SteeringWheel;
        steeringInput = Mathf.Lerp(MinSteeringValue, MaxSteeringValue, Mathf.InverseLerp(-32768, 32767, RawInput));
    }





}
