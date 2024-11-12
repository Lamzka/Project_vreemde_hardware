using UnityEngine;

public class PedalInput : MonoBehaviour
{
    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

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
        GasPedalValue = NormalizeRawInput(rec.Gaspedal);
        BreakPedalValue = NormalizeRawInput(rec.BreakPedal);
        /*ClutchPedalValue = NormalizeRawInput(rec.ClutchPedal);*/
    }

    public float NormalizeRawInput(int rawValue)
    {
        return Mathf.InverseLerp(-32768, 32767, rawValue);
    }
}


