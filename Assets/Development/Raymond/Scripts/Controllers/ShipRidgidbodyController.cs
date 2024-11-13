using UnityEngine;

public class ShipRidgidbodyController : MonoBehaviour, IRidgidBodyButtons, IRidgidBodyPedals
{

    //ridigboy component of the ship
    [SerializeField] private Rigidbody ridgidBody;

    //if the ridgidbody is using gravity or not
    [SerializeField] private bool isUsingGravity;

    //the force that will be applied to the ridigbody according to the action
    [SerializeField] private float maxMovementForce;
    [SerializeField] private float hightForce;

    //the smoothing that will apply to the force so there is no sudden change in movement
    [SerializeField] private float hightForceSmoothing;

    void Start()
    {
        ridgidBody = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        GetComponent<RidgitbodyButtonSubject>().SetListeners(this);
        GetComponent<RidgitBodyPedalSubject>().SetListeners(this);
    }

    private void OnDisable()
    {
        GetComponent<RidgitbodyButtonSubject>().RemoveListeners(this);
        GetComponent<RidgitBodyPedalSubject>().RemoveListeners(this);
    }

    public void OnNotify(int Button)
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
            float AppliedForce = Mathf.Lerp(ridgidBody.velocity.y, maxMovementForce, intensity * Time.deltaTime);
            ridgidBody.AddRelativeForce(Vector3.forward * AppliedForce, ForceMode.Force);
        }
    }

    private void Break(float intensity)
    {
        ridgidBody.drag = intensity;
    }

    private void Backward(float intensity)
    {

    }

    private void MoveUp(int isUp)
    {

        if (isUp == 14)
        {
            Debug.Log("Move up");
            float AppliedForce = Mathf.Lerp(ridgidBody.velocity.y, hightForce, hightForceSmoothing * Time.deltaTime);
            ridgidBody.AddRelativeForce(Vector3.up * AppliedForce, ForceMode.Force);
        }
    }

    private void MoveDown(int isDown)
    {

        if (isDown == 15)
        {
            Debug.Log("moveDown");
            float AppliedForce = Mathf.Lerp(ridgidBody.velocity.y, hightForce, hightForceSmoothing * Time.deltaTime);
            ridgidBody.AddRelativeForce(Vector3.down * -AppliedForce, ForceMode.Force);
        }
    }

    private void TakeOffOrLand(int isPressed)
    {
        if (isPressed == 0 && isUsingGravity)
        {
            Debug.Log("Facebutton 0 pressed");
            isUsingGravity = false;
            ridgidBody.useGravity = isUsingGravity;
            ridgidBody.AddRelativeForce(Vector3.up * 1, ForceMode.Force);

        }
        else if (isPressed == 0 && !isUsingGravity)
        {
            isUsingGravity = true;
            ridgidBody.useGravity = isUsingGravity;
        }
    }



}
