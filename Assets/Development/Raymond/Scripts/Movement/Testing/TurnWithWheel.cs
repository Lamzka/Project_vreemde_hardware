using UnityEngine;

public class TurnWithWheel : MonoBehaviour, IWheelInput
{

    //Settings that will be applied to the ridgidbody
    [Header("RigidBody Settings")]
    public float maxAngularVelocity = 30;
    public float Torque = 1f;

    [SerializeField] private float minTurnSpeed = -2;
    [SerializeField] private float maxTurnSpeed = 2;

    //Force's that will be applied to the steering wheel pasively (Recomend only changing these values in the editor)
    [Header("SteeringWheel SpringForce settings")]
    public int Offset = 0;
    public int Saturation = 0;
    public int Coefficient = 0;


    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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


        //Update the LogitechGSDK's InputManager
        LogitechGSDK.LogiUpdate();

        ApplyPasiveForceFeedback();


    }

    void FixedUpdate()
    {
        rigidbody.maxAngularVelocity = maxAngularVelocity;

        rigidbody.angularVelocity = Vector3.up * Mathf.Clamp(rigidbody.angularVelocity.y, minTurnSpeed, maxTurnSpeed); //max draaisnelheid
    }

    //Called by the WheelInputSubject to update the steering wheel input
    public void OnWheelInput(float input)
    {
        Rotate(input);
    }

    //Rotate the ridgidbody according to the input
    private void Rotate(float NormalizedInput)
    {
        rigidbody.AddRelativeTorque(Vector3.up * Torque * NormalizedInput, ForceMode.Force);
    }

    //Apply the passive force feedback to the steering wheel
    private void ApplyPasiveForceFeedback()
    {
        LogitechGSDK.LogiPlaySpringForce(0, Offset, Saturation, Coefficient);
    }

}
