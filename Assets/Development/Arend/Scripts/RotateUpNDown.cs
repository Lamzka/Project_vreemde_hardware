using UnityEngine;

public class RotateUpNDown : MonoBehaviour, IButtonInput
{
    public Rigidbody rigidbody;

    private LogitechGSDK.DIJOYSTATE2ENGINES rec;

    [SerializeField] private float speed = 1;


    private float rotationValue;


    private void Update()
    {
        rigidbody.transform.Rotate(rotationValue, 0, 0);

    }


    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().SetListeners(this);
    }

    void OnDisable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().RemoveListeners(this);
    }

    public void OnButton(int Button, bool state)
    {
        switch (Button, state)
        {
            case (12, true):
                RotateUp(Button);
                break;
            case (13, true):
                RotateDown(Button);
                break;
            case (12, false):
                ResetRotation();
                break;
            case (13, false):
                ResetRotation();
                break;

        }
    }

    private void RotateUp(int isUp)
    {

        if (isUp == 12)
        {
            Debug.Log("Move up");
            rotationValue = 0.1f;

        }
    }

    private void RotateDown(int isDown)
    {
        if (isDown == 13)
        {
            Debug.Log("moveDown");
            rotationValue = -0.1f;
        }
    }

    private void ResetRotation()
    {
        rotationValue = 0;
    }






}
