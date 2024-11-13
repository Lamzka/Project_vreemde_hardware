using UnityEngine;

public class TurnWithWheel : MonoBehaviour
{
    private SteeringWheelInput steeringWheelInput;

    [SerializeField] private Rigidbody ridgidBody;

    public float MaxSteeringForceValue = 90;
    public float MinSteeringForceValue = -90;

    public int offset = 0;
    public int saturation = 0;
    public int coefficient = 0;

    public bool PedalIsPressed;
    public float Torque = 5f;

    private Transform Object;
    private float NormalizedInput;

    private void Start()
    {
        steeringWheelInput = GetComponent<SteeringWheelInput>();
        ridgidBody = GetComponent<Rigidbody>();

    }


    private void Update()
    {

        LogitechGSDK.LogiUpdate();
        LogitechGSDK.LogiPlaySpringForce(0, offset, saturation, coefficient);


        Object = this.transform;
        NormalizedInput = Mathf.Lerp(MinSteeringForceValue, MaxSteeringForceValue, Mathf.InverseLerp(-360, 360, steeringWheelInput.steeringInput));
        Rotate();

    }

    private void Rotate()
    {
        ridgidBody.AddRelativeTorque(Vector3.up * Torque * NormalizedInput, ForceMode.Force);

    }

}
