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


    }

    private void Update()
    {

        rec = LogitechGSDK.LogiGetStateUnity(0);

        LogitechGSDK.LogiControllerPropertiesData actualProperties = new LogitechGSDK.LogiControllerPropertiesData();
        LogitechGSDK.LogiGetCurrentControllerProperties(0, ref actualProperties);
        GetWheelInput();
        GetPedals();
        /*GetButtons();*/

    }

    void GetWheelInput()
    {
        float RawInput;
        RawInput = rec.SteeringWheel;
        steeringInput = Mathf.Lerp(MinSteeringValue, MaxSteeringValue, Mathf.InverseLerp(-32768, 32767, RawInput));
    }



    void GetPedals()
    {
        gasPedalInput = rec.Gaspedal;
        brakePedalInput = rec.BreakPedal;
        /*ClutchPedalInput = rec.ClutchPedal;*/
    }

    void GetButtons()
    {
        for (int i = 0; i < 128; i++)
        {
            if (rec.rgbButtons[i] == 128)
            {

            }

        }
    }

}
