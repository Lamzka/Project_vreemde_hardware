using UnityEngine;

public class TurnWithWheel : MonoBehaviour, IWheelInput
{

    //Settings that will be applied to the ridgidbody
    [Header("RigidBody Settings")]
    public float maxAngularVelocity = 30;
    public float Torque = 0.5f;

    [SerializeField] private float minTurnSpeed = -2;
    [SerializeField] private float maxTurnSpeed = 1;

    //Force's that will be applied to the steering wheel pasively (Recomend only changing these values in the editor)
    [Header("SteeringWheel SpringForce settings")]
    public int Offset = 0;
    public int Saturation = 0;
    public int Coefficient = 0;


    private Rigidbody rigidbody;

    [SerializeField] private const float DeadzoneMin = -1f;
    [SerializeField] private const float DeadzoneMax = 1f;

    [SerializeField] private GameObject wheel;
    public float rotationSpeed = 100f; // Aanpasbare rotatiesnelheid
    private float currentWheelRotation = 0f; // Houd de rotatie van het stuur bij



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
        /*rigidbody.maxAngularVelocity = maxAngularVelocity;*/

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
        if (NormalizedInput > DeadzoneMin && NormalizedInput < DeadzoneMax)
        {
            NormalizedInput = 0f;
        }

        rigidbody.AddRelativeTorque(Vector3.up * Torque * NormalizedInput, ForceMode.Force);
        // Debug.Log("Wheel Input: " + NormalizedInput);

        currentWheelRotation += NormalizedInput * rotationSpeed * Time.deltaTime; //deze en de 2 regels hieronder toegevoegd voor rotatie wiel, testen, asl niet werkt hier aanpassen!!
        currentWheelRotation = Mathf.Clamp(currentWheelRotation, -450f, 450f);

        wheel.transform.localRotation = Quaternion.Euler(currentWheelRotation, 0, 0);

    }

    //Apply the passive force feedback to the steering wheel
    private void ApplyPasiveForceFeedback()
    {
        LogitechGSDK.LogiPlaySpringForce(0, Offset, Saturation, Coefficient);
    }

    /*private void RotateTheWheel()
    {
        if (Input.GetKey(KeyCode.E))
        {
            wheel.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self); // Rotatie op X-as in lokale ruimte
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            wheel.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
        }

    }*/
}
