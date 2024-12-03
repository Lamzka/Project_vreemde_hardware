using UnityEngine;

public class PedalInput : PedalInputSubject
{
    //refrence to the LogitechGSDK's InputManager
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

    //The boounds set to calculate the normalized input
    public float MaxPedalValue = 100;
    public float MinPedalValue = 0;

    //Output value of the pedals
    [SerializeField] private float gasPedalValue;
    [SerializeField] private float breakPedalValue;

    // Update is called once per frame
    void Update()
    {
        //update the Information from the wheel and the buttons
        LogitechGSDK.LogiUpdate();

        //returns the state of the controller and stores it in rec
        rec = LogitechGSDK.LogiGetStateUnity(0);

        //Calculate the normalized current input of the pedals
        SetPedalInput();
    }


    public void SetPedalInput()
    {

        //sets and sends the normalized input of the gas pedal to the observers
        OnGasPedal(gasPedalValue = NormalizeRawInput(rec.Gaspedal));

        //sets and sends the normalized input of the break pedal to the observers
        OnBreakPedal(breakPedalValue = NormalizeRawInput(rec.BreakPedal));

        /*ClutchPedalValue = NormalizeRawInput(rec.ClutchPedal);*/
    }

    //Calculates the normalized input of the pedals
    public float NormalizeRawInput(int rawValue)
    {
        //Calcutation that normalizes the raw input of the pedals
        return Mathf.Lerp(MaxPedalValue, MinPedalValue, Mathf.InverseLerp(-32768, 32767, rawValue));
    }
}


