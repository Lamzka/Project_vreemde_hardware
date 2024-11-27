using UnityEngine;

public class ShipRidgidbodyController : MonoBehaviour, IButtonInput, IPedalInput
{


    [SerializeField] private Rigidbody rigidbody; //ridigboy component of the ship


    [SerializeField] private bool isUsingGravity;

    [SerializeField] private bool ismovingVerticaly;
    [SerializeField] private bool isReversed;

    [SerializeField] private int currentShifterGear;

    //the force that will be applied to the ridigbody according to the action
    [SerializeField] private float maxMovementForce;
    [SerializeField] private float hightForce;

    [SerializeField] private float maxPedalForce;

    //the smoothing that will apply to the force so there is no sudden change in movement
    [SerializeField] private float hightForceSmoothing;

    [SerializeField] private float minSpeed = 10;
    [SerializeField] private float maxSpeed = 100;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().SetListeners(this);
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<PedalInputSubject>().SetListeners(this);

    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().RemoveListeners(this);
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<PedalInputSubject>().RemoveListeners(this);
    }

    public void OnButton(int button, bool state)
    {
        switch (button, state)
        {
            case (0, true): TakeOffOrLand(button, state); break;


            case (14, true):
                currentShifterGear = 14;
                ismovingVerticaly = true;
                break;

            case (14, false): ismovingVerticaly = false; break;

            case (15, true):
                currentShifterGear = 15;
                ismovingVerticaly = true;
                break;

            case (15, false): ismovingVerticaly = false; break;

            case (18, true): isReversed = true; break;
            case (18, false): isReversed = false; break;
        }
    }

    public void OnGasPedal(float GasValue)
    {
        HorizontalMovement(GasValue);
    }

    public void OnBreakPedal(float BreakValue)
    {
        Break(BreakValue);
    }

    private void FixedUpdate()
    {
        if (ismovingVerticaly)
            VerticalMovement(currentShifterGear, ismovingVerticaly);

    }


    private void HorizontalMovement(float intensity) //iets om gewoon vooruit te gaan
    {
        float AppliedForce = Mathf.Clamp(intensity, 0, maxMovementForce);
        Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
        Vector3 forceDirection = Vector3.zero;

        localVelocity.z = Mathf.Clamp(localVelocity.z, minSpeed, maxSpeed);

        switch (isUsingGravity, isReversed, intensity)
        {

            case (false, false, 0): rigidbody.drag = 0; break;
            case (false, true, 0): rigidbody.drag = 0; break;


            case (true, false, > 0): // when is using gravity and isnt going in reverse

                break;

            case (false, false, > 0): // when is not using gravity and isnt going in reverse
                forceDirection = Vector3.forward;
                rigidbody.drag = 3;
                break;

            case (true, true, > 0): // when is using gravity and is going in reverse

                break;

            case (false, true, > 0): // when is not using gravity and is going in reverse
                forceDirection = Vector3.back;
                rigidbody.drag = 3;
                break;
        }

        if (intensity > 0)
        {
            /*rigidbody.velocity = transform.TransformDirection(localVelocity);*/
            rigidbody.AddRelativeForce(forceDirection * AppliedForce, ForceMode.Force);
        }

    }


    private void Break(float intensity)
    {
        float pedalForceInput = Mathf.Clamp(intensity, 0, maxPedalForce);

        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, pedalForceInput * Time.deltaTime);
    }

    private void VerticalMovement(int button, bool state)
    {
        float AppliedForce = Mathf.Lerp(rigidbody.velocity.y, hightForce, hightForceSmoothing * Time.deltaTime);
        Vector3 forceDirection;

        switch (button, state)
        {
            default:
                forceDirection = Vector3.zero;

                break;
            case (14, true):
                forceDirection = Vector3.up;

                break;
            case (15, true):
                forceDirection = Vector3.down;

                break;
        }

        rigidbody.AddRelativeForce(forceDirection * AppliedForce, ForceMode.Force);
    }

    private void TakeOffOrLand(int button, bool isButttonPressed)
    {

        switch (button, isButttonPressed, isUsingGravity)
        {
            case (0, true, true): isUsingGravity = false; break;
            case (0, true, false): isUsingGravity = true; break;
        }

        rigidbody.useGravity = isUsingGravity;
    }



}
