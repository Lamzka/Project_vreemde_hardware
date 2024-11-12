using System.Collections.Generic;

public class WheelButtonInput : RidgitbodyButtonSubject
{
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

    public List<bool> buttonStates = new List<bool>(new bool[128]);
    bool isBeingPressed = false;

    float timer = 0;

    private void Start()
    {
        LogitechGSDK.LogiSteeringInitialize(true);
    }

    void Update()
    {
        LogitechGSDK.LogiUpdate();

        UpdateButtonStates();
    }

    void UpdateButtonStates()
    {
        timer++;

        for (int i = 0; i < buttonStates.Count; i++)
        {
            bool isPressed = LogitechGSDK.LogiButtonIsPressed(0, i);
            LogitechGSDK.LogiButtonReleased(0, i);
            buttonStates[i] = isPressed;

            if (isPressed && timer > 50)
            {
                OnNotify(i);
                timer = 0;
            }
        }
    }

}
