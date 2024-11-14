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
        timer++;

        //Forloop to check each button
        for (int i = 0; i < buttonStates.Count; i++)
        {
            //if a button is pressed the bool isPressed will be set to true
            bool isPressed = LogitechGSDK.LogiButtonIsPressed(0, i);

            //if a button is pressed it will set its corrosponding index in the list to true
            buttonStates[i] = isPressed;

            //if a button is pressed and the timer is greater than 60 it will notify the observers
            if (isPressed && timer > 60)
            {
                //Notify the observers
                OnNotify(i);

                //reset the timer
                timer = 0;
            }
        }
    }

}
