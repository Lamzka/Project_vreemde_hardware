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
                TakeOffOrLand(Button, state);
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


    private void Forward(float intensity) //iets om gewoon vooruit te gaan
    {
        if (intensity > 0 && !isUsingGravity)
        {
            //if (intensity > 0) //intensity is 100 wanneer ingedrukt
            // {
            //float AppliedForce = Mathf.Clamp(intensity * Time.deltaTime, maxMovementForce, intensity * Time.deltaTime);
            //rigidbody.AddRelativeForce(Vector3.forward * AppliedForce, ForceMode.Acceleration);
            //float AppliedForce = Mathf.Clamp(intensity * Time.deltaTime, 0, maxMovementForce);
            //rigidbody.AddRelativeForce(Vector3.forward * AppliedForce, ForceMode.Acceleration);
            float AppliedForce = Mathf.Clamp(intensity, 0, maxMovementForce);
            rigidbody.AddRelativeForce(Vector3.forward * AppliedForce, ForceMode.Force);


            Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
            localVelocity.z = Mathf.Clamp(localVelocity.z, minSpeed, maxSpeed);
            rigidbody.velocity = transform.TransformDirection(localVelocity);
            //rigidbody.velocity = Vector3.forward * Mathf.Clamp(rigidbody.velocity.z, minSpeed, maxSpeed);
            // }

        }
    }


    private void Break(float intensity)
    {
        /*if (intensity > 0)
        {
            rigidbody.drag = Mathf.Clamp(intensity * Time.deltaTime, 3f, 40f);
        }
        else
        {
            rigidbody.drag = defaultDrag;
        }*/
    }

    private void Backward(float intensity)
    {

    }

    private void MoveUp(int isUp) //set in fixedUpdate
    {

        if (isUp == 14)
        {
            Debug.Log("Move up");
            float AppliedForce = Mathf.Lerp(rigidbody.velocity.y, hightForce, hightForceSmoothing * Time.deltaTime);
            rigidbody.AddRelativeForce(Vector3.up * AppliedForce, ForceMode.Force);
            rigidbody.velocity = Vector3.up * AppliedForce;

        }
    }

    private void MoveDown(int isDown)// set in fixedupdate
    {
        if (isDown == 15)
        {
            Debug.Log("moveDown");
            float AppliedForce = Mathf.Lerp(rigidbody.velocity.y, hightForce, hightForceSmoothing * Time.deltaTime);
            rigidbody.AddRelativeForce(Vector3.down * -AppliedForce, ForceMode.Force);
            rigidbody.velocity = Vector3.down * AppliedForce;
        }
    }

    private void TakeOffOrLand(int isPressed, bool isButttonPressed)
    {
        rigidbody.useGravity = isUsingGravity;

        if (isPressed == 0 && isUsingGravity && isButttonPressed == true)
        {
            Debug.Log("Facebutton 0 pressed");
            isUsingGravity = false;

            /*ridgidBody.AddRelativeForce(Vector3.up * 1, ForceMode.Impulse);*/
        }

        else if (isPressed == 0 && !isUsingGravity && isButttonPressed == true)
        {
            isUsingGravity = true;
        }
    }



}
