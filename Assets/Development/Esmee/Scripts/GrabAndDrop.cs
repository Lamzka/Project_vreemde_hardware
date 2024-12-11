using UnityEngine;

public class GrabAndDrop : QuestInfoSubject, IButtonInput
{
    public int ButtonIndex = 1; //integer corosponding to the button that will be used to pick up and drop the package

    public bool isCollected; //if a package collected by the ship

    [SerializeField] private bool canCollect; //if the ship can collect a package

    [SerializeField] private float followSpeed = 10.0f; //speed at which the package follows the ship
    [SerializeField] private float packageDrag = 5f; //drag on the package
    [SerializeField] private float packageDampening = 0.5f; //dampening on the package movenent 


    private GameObject package; //hij pakt nu altijd deze package

    private Rigidbody packageRigidbody;

    private float dropOffset = 2.0f; //offset from the ship where the package will be dropped

    [SerializeField] private GameObject grabbed;
    [SerializeField] private GameObject notGrabbed;

    void Start()
    {
        canCollect = false;
        isCollected = false;
    }

    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().SetListeners(this); //Set this class as a listener to the ButtonInputSubject
    }

    void OnDisable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().RemoveListeners(this); //remove this class as a listener to the ButtonInputSubject
    }

    private void FixedUpdate()
    {
        if (isCollected) //if a package is collected by the ship make it follow the ship
            PackageFollowShip();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "package")
        {
            canCollect = true;

            package = other.gameObject; //dit kan zolang we het erbij houden dat we 1 package steeds uit het 'magazijn' meenemen

            packageRigidbody = other.GetComponent<Rigidbody>();

            OnSecurePackage(other.GetComponent<Package>().Info);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "package")
        {
            canCollect = false;

            package = null; //dit kan zolang we het erbij houden dat we 1 package steeds uit het 'magazijn' meenemen

            packageRigidbody = null;

            OnSecurePackage(null);
        }
    }

    public void OnButton(int button, bool state) //this function is called by the ButtonInputSubject, it returns the value of the button that is pressed
    {
        PackageCollecting(button, state);
    }



    private void Update() //testing function to simulate the button press
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PackageCollecting(ButtonIndex, true);
        }
    }


    private void PackageCollecting(int button, bool state)
    {
        if (button == ButtonIndex && state == true && canCollect == true && isCollected == false) //if the button is pressed and the ship can collect a package and the ship has not collected a package yet
        {
            canCollect = false;

            packageRigidbody.useGravity = false;

            isCollected = true;

            notGrabbed.gameObject.SetActive(false);
            grabbed.gameObject.SetActive(true);
        }
        else if (button == ButtonIndex && state == true && canCollect == false && isCollected == true) //if the button is pressed and the ship can not collect a package and the ship has collected a package
        {
            isCollected = false;

            packageRigidbody.useGravity = true;

            canCollect = true;

            //Reset Package value's
            package = null;
            packageRigidbody = null;

            notGrabbed.gameObject.SetActive(true);
            grabbed.gameObject.SetActive(false);
        }
    }


    private void PackageFollowShip() //function to make the package follow the ship
    {
        Vector3 targetPosition = transform.position + transform.forward * dropOffset - package.transform.position; //Calculate the position the package should be at

        Vector3 force = (targetPosition * followSpeed) - (packageRigidbody.velocity * packageDampening); //Calculate the force that should be applied to the package to get to the target position


        packageRigidbody.velocity = Vector3.Lerp(packageRigidbody.velocity, Vector3.zero, packageDrag * Time.fixedDeltaTime); //Apply drag to the package

        packageRigidbody.AddForce(force, ForceMode.Impulse);//Apply the force to the package
        packageRigidbody.MoveRotation(transform.rotation); //Make sure the package is always facing the same direction as the ship
    }
}
