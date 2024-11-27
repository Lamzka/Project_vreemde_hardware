using UnityEngine;

public class Sidewaysshiprotation : MonoBehaviour, IButtonInput
{
    [SerializeField] private float minTurnSpeed;
    [SerializeField] private float maxTurnSpeed;

    private Rigidbody rigidbody;

    public float Torque = 0.5f;

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
        rigidbody.angularVelocity = Vector3.forward * Mathf.Clamp(rigidbody.angularVelocity.z, minTurnSpeed, maxTurnSpeed);
    }

    public void OnButton(int Button, bool state)
    {
        switch (Button, state)
        {
            case (4, true):
                RotateRight();
                break;
            case (5, true):
                RotateLeft();
                break;
        }
    }

    private void RotateRight()
    {
        rigidbody.AddRelativeTorque(Vector3.forward * Torque, ForceMode.Impulse);
    }

    private void RotateLeft()
    {
        rigidbody.AddRelativeTorque(Vector3.back * Torque, ForceMode.Impulse);
    }
}
