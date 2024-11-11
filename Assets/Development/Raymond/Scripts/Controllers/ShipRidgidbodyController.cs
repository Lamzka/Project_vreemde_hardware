using UnityEngine;

public class ShipRidgidbodyController : MonoBehaviour, IRidgidBodyButtons
{

    [SerializeField]
    private Rigidbody ridgidBody;

    private bool isKinimatic;

    private float hightForce;

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
        Debug.Log("Move up");
        if (isUp == 14)
        {
            float AppliedForce = Mathf.Lerp(ridgidBody.velocity.y, hightForce, ForceSmoothing * Time.deltaTime);
            ridgidBody.AddForce(0, AppliedForce, 0, ForceMode.Acceleration);
        }
    }

    private void MoveDown(int isDown)
    {
        Debug.Log("moveDown");
        if (isDown == 15)
        {
            float AppliedForce = Mathf.Lerp(ridgidBody.velocity.y, hightForce, ForceSmoothing * Time.deltaTime);
            ridgidBody.AddForce(0, -AppliedForce, 0, ForceMode.Acceleration);
        }
    }

    private void TakeOffOrLand(int isPressed)
    {
        Debug.Log("Facebutton 0 pressed");
        if (isPressed == 0 && !isKinimatic)
        {
            isKinimatic = true;
            ridgidBody.isKinematic = isKinimatic;
            ridgidBody.AddForce(0, 0.5f, 0, ForceMode.Impulse);

        }
        else if (isPressed == 0 && isKinimatic)
        {
            isKinimatic = false;
            ridgidBody.isKinematic = isKinimatic;
        }
    }



}
