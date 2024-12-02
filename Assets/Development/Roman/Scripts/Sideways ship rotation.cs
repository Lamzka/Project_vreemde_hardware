using UnityEngine;

public class Sidewaysshiprotation : MonoBehaviour, IButtonInput
{
    public float Torque = 0.5f;

    public float SmoothingTime;

    private Rigidbody rigidbody;

    [SerializeField] private float maxDrag;
    [SerializeField] private float minTurnSpeed;
    [SerializeField] private float maxTurnSpeed;

    private Vector3 rotationDirection;

    private int currenttButton;

    private bool isBeingPressed;




    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().SetListeners(this);
    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().RemoveListeners(this);
    }

    void FixedUpdate()
    {


        if (isBeingPressed)
        {
            rigidbody.angularVelocity = Vector3.forward * Mathf.Clamp(rotationDirection.z, minTurnSpeed, maxTurnSpeed);
            RotateRight();
        }
        else
        {
            rigidbody.angularVelocity = Vector3.Lerp(rigidbody.angularVelocity, Vector3.zero, SmoothingTime * Time.deltaTime);
        }




    }

    public void OnButton(int button, bool state)
    {
        HandleInput(button, state);
    }

    private void HandleInput(int button, bool state)
    {
        switch (button, state)
        {
            default:
                isBeingPressed = false;
                /*rotationDirection = Vector3.zero;*/
                break;
            case (4, true):
                rotationDirection = Vector3.back;
                isBeingPressed = true;
                break;
            case (5, true):
                rotationDirection = Vector3.forward;
                isBeingPressed = true;
                break;`
            case (12, true):
                rotationDirection = Vector3.right;
                isBeingPressed = true;
                break;
            case (13, true):
                rotationDirection = Vector3.left;
                isBeingPressed = true;
                break;
        }
    }

    private void RotateRight()
    {
        /*rigidbody.angularDrag = Mathf.Lerp(maxDrag, 0.5f, SmoothingTime * Time.deltaTime);*/
        rigidbody.AddRelativeTorque(rotationDirection * Torque, ForceMode.Force);

    }


}
