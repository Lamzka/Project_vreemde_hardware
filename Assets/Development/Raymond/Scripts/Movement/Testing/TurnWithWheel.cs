using UnityEngine;

public class TurnWithWheel : MonoBehaviour, IWheelInput
{

    //Settings that will be applied to the ridgidbody
    [Header("RidgidBody Settings")]
    public float maxAngularVelocity = 30;
    public float Torque = 1f;

    //Force's that will be applied to the steering wheel pasively (Recomend only changing these values in the editor)
    [Header("SteeringWheel SpringForce settings")]
    public int offset = 0;
    public int saturation = 0;
    public int coefficient = 0;


    private Rigidbody ridgidBody;

    private void Start()
    {
        ridgidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //Set this class as a listener to the WheelInputSubject
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<WheelInputSubject>().SetListeners(this);
    }

    private void OnDisable()
    {
        //remove this class as a listener to the WheelInputSubject
        GetComponent<WheelInputSubject>().RemoveListeners(this);
    }

    private void Update()
    {
        //Set the maxAngularVelocity of the ridgidbody to declared variable
        ridgidBody.maxAngularVelocity = maxAngularVelocity;

        //Update the LogitechGSDK's InputManager
        LogitechGSDK.LogiUpdate();

        ApplyPasiveForceFeedback();
    }

    //Called by the WheelInputSubject to update the steering wheel input
    public void OnWheelInput(float input)
    {
        Rotate(input);
    }

    //Rotate the ridgidbody according to the input
    private void Rotate(float NormalizedInput)
    {
        ridgidBody.AddRelativeTorque(Vector3.up * Torque * NormalizedInput, ForceMode.Force);
    }

    //Apply the passive force feedback to the steering wheel
    private void ApplyPasiveForceFeedback()
    {
        LogitechGSDK.LogiPlaySpringForce(0, offset, saturation, coefficient);
    }

}
