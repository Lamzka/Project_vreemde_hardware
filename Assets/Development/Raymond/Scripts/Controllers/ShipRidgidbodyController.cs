using UnityEngine;

public class ShipRidgidbodyController : MonoBehaviour, IButtonInput, IPedalInput
{

    //ridigboy component of the ship
    [SerializeField] private Rigidbody rigidbody;

    //if the ridgidbody is using gravity or not
    [SerializeField] private bool isUsingGravity;

    //the force that will be applied to the ridigbody according to the action
    [SerializeField] private float maxMovementForce;
    [SerializeField] private float hightForce;

    //the smoothing that will apply to the force so there is no sudden change in movement
    [SerializeField] private float hightForceSmoothing;

    [SerializeField] private float minSpeed = 10;
    [SerializeField] private float maxSpeed = 100;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        /*  Debug.Log(ridgidBody.velocity);*/

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

    public void OnButton(int Button, bool state)
    {
        switch (Button)
        {
            case 0: //X button
                TakeOffOrLand(Button);
                break;
            case 1: //Square button
                //button1
                break;
            case 2: //Circle button
                //button2
                break;
            case 3: //Triangle button
                //button3
                break;
            case 12: //Shifter First Gear
                //Gear1
                break;
            case 13: //Shifter Second Gear
                //Gear2
                break;
            case 14: //Shifter Third Gear
                MoveUp(Button);
                break;
            case 15: //Shifter Fourth Gear
                MoveDown(Button);
                break;
            case 16: //Shifter Fifth Gear
                //Gear5
                break;
            case 17: //Shifter Sixth Gear
                //Gear6
                break;
            case 18: //Shifter Reverse Gear
                Backward(Button);
                break;
        }
    }

    public void OnGasPedal(float GasValue)
    {
        Forward(GasValue);
    }

    public void OnBreakPedal(float BreakValue)
    {
        Break(BreakValue);
    }


    private void Forward(float intensity)
    {

        if (!isUsingGravity)
        {
            float AppliedForce = Mathf.Clamp(rigidbody.velocity.z, maxMovementForce, intensity * Time.deltaTime);
            rigidbody.AddRelativeForce(Vector3.forward * AppliedForce, ForceMode.Acceleration);



            rigidbody.angularVelocity = Vector3.forward * Mathf.Clamp(rigidbody.angularVelocity.z, minSpeed, maxSpeed);
            Debug.Log(intensity);

        }
    }

    private void Break(float intensity)
    {

        rigidbody.drag = Mathf.Clamp(40f, 10f, intensity * Time.deltaTime);
    }

    private void Backward(float intensity)
    {

    }

    private void MoveUp(int isUp)
    {

        if (isUp == 14)
        {
            Debug.Log("Move up");
            float AppliedForce = Mathf.Lerp(rigidbody.velocity.y, hightForce, hightForceSmoothing * Time.deltaTime);
            rigidbody.AddRelativeForce(Vector3.up * AppliedForce, ForceMode.Impulse);
            rigidbody.velocity = Vector3.up * AppliedForce;

        }
    }

    private void MoveDown(int isDown)
    {

        if (isDown == 15)
        {
            Debug.Log("moveDown");
            float AppliedForce = Mathf.Lerp(rigidbody.velocity.y, hightForce, hightForceSmoothing * Time.deltaTime);
            rigidbody.AddRelativeForce(Vector3.down * -AppliedForce, ForceMode.Impulse);
            rigidbody.velocity = Vector3.down * AppliedForce;
        }
    }

    private void TakeOffOrLand(int isPressed)
    {
        if (isPressed == 0 && isUsingGravity)
        {
            Debug.Log("Facebutton 0 pressed");
            isUsingGravity = false;
            rigidbody.useGravity = isUsingGravity;

            /*ridgidBody.AddRelativeForce(Vector3.up * 1, ForceMode.Impulse);*/


        }
        else if (isPressed == 0 && !isUsingGravity)
        {
            isUsingGravity = true;
            rigidbody.useGravity = isUsingGravity;
        }
    }



}
