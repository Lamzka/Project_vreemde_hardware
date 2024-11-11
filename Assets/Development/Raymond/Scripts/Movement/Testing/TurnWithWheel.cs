using UnityEngine;

public class TurnWithWheel : MonoBehaviour
{
    private SteeringWheelInput steeringWheelInput;


    public float MaxSteeringValue = 90;
    public float MinSteeringValue = -90;

    public bool PedalIsPressed;
    public float Smoothing = 5f;

    private Transform Object;
    private float NormalizedInput;

    private void Start()
    {
        steeringWheelInput = GetComponent<SteeringWheelInput>();
    }


    private void Update()
    {
        Object = this.transform;
        NormalizedInput = Mathf.Lerp(MinSteeringValue, MaxSteeringValue, Mathf.InverseLerp(-360, 360, steeringWheelInput.steeringInput));
        Rotate();

    }

    private void Rotate()
    {




        if (PedalIsPressed)
        {
            Object.rotation = Quaternion.Slerp(Object.rotation, Quaternion.Euler(NormalizedInput, 0, 0), Time.deltaTime * Smoothing);

        }
        else
        {
            Object.rotation = Quaternion.Slerp(Object.rotation, Quaternion.Euler(0, NormalizedInput, 0), Time.deltaTime * Smoothing);
        }
    }

}
