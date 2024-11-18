using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

    private float speed = 5;

    void Start()
    {
        transform.position = Vector3.zero;
    }

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
                Gear3(i);
                Gear4(i);
            }
        }
    }


    public bool Gear3(byte button14)
    {
        if (button14 == 14)
        {
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
            transform.position = new Vector3(transform.position.x, (transform.position.y - (Time.deltaTime * speed)), transform.position.z);
            return true;
        }
        else
        {
            return false;
        }
    }
}
