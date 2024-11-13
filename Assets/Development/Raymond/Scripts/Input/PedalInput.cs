using UnityEngine;

public class PedalInput : RidgitBodyPedalSubject
{
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

    public float MaxPedalValue = 100;

    public float MinPedalValue = 0;

    [SerializeField]
    private float GasPedalValue;

    [SerializeField]
    float BreakPedalValue;

    // Update is called once per frame
    void Update()
    {
        LogitechGSDK.LogiUpdate();

        rec = LogitechGSDK.LogiGetStateUnity(0);

        SetPedalInput();

    }

    public void SetPedalInput()
    {
        OnGasPedal(GasPedalValue = NormalizeRawInput(rec.Gaspedal));
        OnBreakPedal(BreakPedalValue = NormalizeRawInput(rec.BreakPedal));
        /*ClutchPedalValue = NormalizeRawInput(rec.ClutchPedal);*/
    }

    public float NormalizeRawInput(int rawValue)
    {
        return Mathf.Lerp(MaxPedalValue, MinPedalValue, Mathf.InverseLerp(-32768, 32767, rawValue));
    }
}


