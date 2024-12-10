using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

    private float speed = 5; // how fast you move up and down

    void Start()
    {
        transform.position = Vector3.zero;
    }

    void Update()
    {
        rec = LogitechGSDK.LogiGetStateUnity(0);
        LogitechGSDK.LogiControllerPropertiesData actualProperties = new LogitechGSDK.LogiControllerPropertiesData();
        LogitechGSDK.LogiGetCurrentControllerProperties(0, ref actualProperties);

        GetButtons(); // Check for button input
    }

    void GetButtons()
    {
        for (byte i = 0; i < 128; i++) // go through all 128 button inputs
        {
            if (rec.rgbButtons[i] == 128) // Check if button is pressed
            {
                Gear3(i);
                Gear4(i);
            }
        }
    }


    public bool Gear3(byte button14)
    {
        if (button14 == 14)
        {
            // Move the ship upwards based on speed and delta time
            transform.position = new Vector3(transform.position.x, (transform.position.y + (Time.deltaTime * speed)), transform.position.z);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Gear4(int button15)
    {
        if (button15 == 15)
        {
            // Move the ship down based on speed and delta time
            transform.position = new Vector3(transform.position.x, (transform.position.y - (Time.deltaTime * speed)), transform.position.z);
            return true;
        }
        else
        {
            return false;
        }
    }
}
