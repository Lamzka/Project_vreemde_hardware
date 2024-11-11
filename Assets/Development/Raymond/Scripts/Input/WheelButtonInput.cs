public class WheelButtonInput : RidgitbodyButtonSubject
{
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

    void Update()
    {
        rec = LogitechGSDK.LogiGetStateUnity(0);
        LogitechGSDK.LogiControllerPropertiesData actualProperties = new LogitechGSDK.LogiControllerPropertiesData();
        LogitechGSDK.LogiGetCurrentControllerProperties(0, ref actualProperties);

        GetButtons();
    }

    void GetButtons()
    {
        for (byte i = 0; i < 128; i++)
        {
            if (rec.rgbButtons[i] == 128)
            {

            }
        }
    }

}
