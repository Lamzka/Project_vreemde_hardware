using UnityEngine;

public class SteeringWheelInput : MonoBehaviour
{
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;
    private LogitechGSDK.LogiControllerPropertiesData properties;

    //SteeringWheel
    public float steeringInput;

    //Pedals
    public float gasPedalInput;
    public float brakePedalInput;
    /*private int ClutchPedalInput[];*/

    //FaceButtons
    public bool button0(int button0)
    {
        if (button0 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool button1(int button1)
    {
        if (button1 == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool button2(int button2)
    {

        if (button2 == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool button3(int button3)
    {
        if (button3 == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Shifter
    public bool gear1(int button12)
    {

        if (button12 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool gear2(int button13)
    {
        if (button13 == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool gear3(int button14)
    {
        if (button14 == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool gear4(int button15)
    {
        if (button15 == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool gear5(int button16)
    {
        if (button16 == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool gear6(int button17)
    {
        if (button17 == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Reverse(int button18)
    {
        if (button18 == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

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
        steeringInput = rec.SteeringWheel;
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
                button0(i);
                button1(i);
                button2(i);
                button3(i);
                gear1(i);
                gear2(i);
                gear3(i);
                gear4(i);
                gear5(i);
                gear6(i);
                Reverse(i);
            }

        }
    }

}
