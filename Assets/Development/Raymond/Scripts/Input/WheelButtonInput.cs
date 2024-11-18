using System.Collections.Generic;

public class WheelButtonInput : ButtonInputSubject
{

    //List with bools for each button on the wheel
    public List<bool> buttonStates = new List<bool>(new bool[128]);

    //Is a button being pressed?
    bool isBeingPressed = false;

    //timer to prevent multiple inputs
    float timer = 0;

    private void Start()
    {
        //Initialize the wheel for good mesure
        LogitechGSDK.LogiSteeringInitialize(true);
    }

    void Update()
    {
        //update the Information from the wheel and the buttons
        LogitechGSDK.LogiUpdate();

        //Update the button states
        UpdateButtonStates();
    }



    //checks if there is a button is pressed on the current frame
    void UpdateButtonStates()
    {
        bool IsHeld = false;

        bool isPressed;

        //Forloop to check each button
        for (int i = 0; i < buttonStates.Count; i++)
        {

            if (LogitechGSDK.LogiButtonIsPressed(0, i) == true && IsHeld == false)
            {
                IsHeld = true;
                isPressed = true;
                buttonStates[i] = isPressed;
                OnNotify(i, isPressed);

            }
            else if (LogitechGSDK.LogiButtonReleased(0, i) == false && IsHeld == true)
            {
                IsHeld = false;
                isPressed = false;
                buttonStates[i] = isPressed;
                OnNotify(i, isPressed);
            }



        }
    }

}
