using UnityEngine;

public class RotationBox : MonoBehaviour
{
    private SteeringWheelInput steeringWheelInput;

    private void Start()
    {
        steeringWheelInput = GetComponent<SteeringWheelInput>();
    }

    private void Update()
    {
        Rotate();

    }

    private void Rotate()
    {
        this.transform.Rotate(0, Mathf.Clamp(steeringWheelInput.steeringInput, -360, 360), 0);
    }

}
