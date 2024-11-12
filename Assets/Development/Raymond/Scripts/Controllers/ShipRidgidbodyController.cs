using UnityEngine;

public class ShipRidgidbodyController : MonoBehaviour, IRidgidBodyButtons
{

    [SerializeField]
    private Rigidbody ridgidBody;

    [SerializeField]
    private bool isUsingGravity;

    [SerializeField]
    private float hightForce;

    [SerializeField]
    private float ForceSmoothing;

    void Start()
    {
        ridgidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GetComponent<RidgitbodyButtonSubject>().SetListeners(this);
    }

    private void OnDisable()
    {
        GetComponent<RidgitbodyButtonSubject>().RemoveListeners(this);
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
                //reverse
                break;
        }
    }


    private void Forward(float intensity)
    {

    }

    private void Backward(float intensity)
    {

    }

    private void MoveUp(int isUp)
    {

        if (isUp == 14)
        {
            Debug.Log("Move up");
            float AppliedForce = Mathf.Lerp(ridgidBody.velocity.y, hightForce, ForceSmoothing * Time.deltaTime);
            ridgidBody.AddForce(0, AppliedForce, 0, ForceMode.Acceleration);
        }
    }

    private void MoveDown(int isDown)
    {

        if (isDown == 15)
        {
            Debug.Log("moveDown");
            float AppliedForce = Mathf.Lerp(ridgidBody.velocity.y, hightForce, ForceSmoothing * Time.deltaTime);
            ridgidBody.AddForce(0, -AppliedForce, 0, ForceMode.Acceleration);
        }
    }

    private void TakeOffOrLand(int isPressed)
    {




        if (isPressed == 0 && isUsingGravity)
        {
            Debug.Log("Facebutton 0 pressed");
            isUsingGravity = false;
            ridgidBody.useGravity = isUsingGravity;
            ridgidBody.AddForce(0, 0.5f, 0, ForceMode.Impulse);

        }
        else if (isPressed == 0 && !isUsingGravity)
        {
            isUsingGravity = true;
            ridgidBody.useGravity = isUsingGravity;
        }
    }



}
