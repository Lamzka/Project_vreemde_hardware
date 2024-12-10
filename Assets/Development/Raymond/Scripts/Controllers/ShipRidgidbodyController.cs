using UnityEngine;

// This script controls the spaceship's movement using a Rigidbody component.
public class ShipRidgidbodyController : MonoBehaviour, IButtonInput, IPedalInput
{
    [SerializeField] private Rigidbody rigidbody; // Rigidbody component controlling the ship's physics.

    [SerializeField] private bool isUsingGravity; // Indicates if the ship is affected by gravity.
    [SerializeField] private bool ismovingVerticaly; // Indicates if the ship is currently moving vertically.
    [SerializeField] private bool isReversed; // Indicates if the ship's movement is reversed.

    [SerializeField] private int currentShifterGear; // Tracks the current gear for vertical movement.

    // Maximum forces for movement and vertical actions.
    [SerializeField] private float maxMovementForce;
    [SerializeField] private float hightForce;

    [SerializeField] private float maxPedalForce; // Maximum force applied when using the brake pedal.

    // Smoothing factor to avoid abrupt changes in vertical force.
    [SerializeField] private float hightForceSmoothing;

    // Speed constraints for the ship's horizontal movement.
    [SerializeField] private float minSpeed = 10;
    [SerializeField] private float maxSpeed = 100;

    [SerializeField] private GameObject shipLights;

    void Start()
    {
        // Assign the Rigidbody component of the game object.
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // Registers this object as a listener for button and pedal inputs from the InputManagers.
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().SetListeners(this);
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<PedalInputSubject>().SetListeners(this);
    }

    private void OnDisable()
    {
        // Removes this object as a listener when it is disabled.
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().RemoveListeners(this);
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<PedalInputSubject>().RemoveListeners(this);
    }

    // Handles button input actions based on the button ID and its state (pressed/released).
    public void OnButton(int button, bool state)
    {
        switch (button, state)
        {
            case (0, true): TakeOffOrLand(button, state); break; // Handles takeoff or landing based on gravity.

            case (14, true): // Moves the ship upwards when gear 14 is active.
                currentShifterGear = 14;
                ismovingVerticaly = true;
                break;

            case (14, false): // Stops vertical movement when gear 14 is released.
                ismovingVerticaly = false;
                break;

            case (15, true): // Moves the ship downwards when gear 15 is active.
                currentShifterGear = 15;
                ismovingVerticaly = true;
                break;

            case (15, false): // Stops vertical movement when gear 15 is released.
                ismovingVerticaly = false;
                break;

            case (18, true): isReversed = true; break; // Enables reverse movement.
            case (18, false): isReversed = false; break; // Disables reverse movement.
        }
    }

    // Handles gas pedal input to move the ship horizontally.
    public void OnGasPedal(float gasValue)
    {
        HorizontalMovement(gasValue);
    }

    // Handles brake pedal input to slow down the ship.
    public void OnBreakPedal(float breakValue)
    {
        Break(breakValue);
    }

    private void FixedUpdate()
    {
        // Handles vertical movement when active.
        if (ismovingVerticaly)
            VerticalMovement(currentShifterGear, ismovingVerticaly);
    }

    // Controls horizontal movement based on the input intensity.
    private void HorizontalMovement(float intensity)
    {
        float appliedForce = Mathf.Clamp(intensity, 0, maxMovementForce); // Limits the applied force.
        Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity); // Converts velocity to local space.
        Vector3 forceDirection = Vector3.zero;

        // Clamps the forward velocity within min and max speed.
        localVelocity.z = Mathf.Clamp(localVelocity.z, minSpeed, maxSpeed);

        // Determines movement behavior based on gravity, reverse mode, and input intensity.
        switch (isUsingGravity, isReversed, intensity)
        {
            case (false, false, 0): rigidbody.drag = 0; break; // No gravity, no reverse, no input.
            case (false, true, 0): rigidbody.drag = 0; break; // No gravity, reverse, no input.

            case (true, false, > 0): // Gravity enabled, forward movement.
                break;

            case (false, false, > 0): // No gravity, forward movement.
                forceDirection = Vector3.forward;
                rigidbody.drag = 3;
                break;

            case (true, true, > 0): // Gravity enabled, reverse movement.
                break;

            case (false, true, > 0): // No gravity, reverse movement.
                forceDirection = Vector3.back;
                rigidbody.drag = 3;
                break;
        }

        if (intensity > 0)
        {
            rigidbody.AddRelativeForce(forceDirection * appliedForce, ForceMode.Force); // Applies force for movement.
        }
    }

    // Smoothly reduces the ship's velocity based on brake input intensity.
    private void Break(float intensity)
    {
        float pedalForceInput = Mathf.Clamp(intensity, 0, maxPedalForce); // Limits brake force.
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, pedalForceInput * Time.deltaTime);
    }

    // Handles vertical movement based on the current gear and its state.
    private void VerticalMovement(int button, bool state)
    {
        float appliedForce = Mathf.Lerp(rigidbody.velocity.y, hightForce, hightForceSmoothing * Time.deltaTime); // Smooth vertical force.
        Vector3 forceDirection;

        switch (button, state)
        {
            default:
                forceDirection = Vector3.zero; // No vertical movement.
                break;

            case (14, true): // Move upwards.
                forceDirection = Vector3.up;
                break;

            case (15, true): // Move downwards.
                forceDirection = Vector3.down;
                break;
        }

        rigidbody.AddRelativeForce(forceDirection * appliedForce, ForceMode.Force); // Applies vertical force.
    }

    // Toggles gravity on or off based on button input and current gravity state.
    private void TakeOffOrLand(int button, bool isButttonPressed)
    {
        switch (button, isButttonPressed, isUsingGravity)
        {
            case (0, true, true): isUsingGravity = false; shipLights.SetActive(true); break;// Disables gravity for takeoff.
            case (0, true, false): isUsingGravity = true; shipLights.SetActive(false); break;// Enables gravity for landing.
        }

        rigidbody.useGravity = isUsingGravity; // Updates Rigidbody gravity state.
    }
}
