using UnityEngine;

public class GrabAndDrop : MonoBehaviour, IButtonInput
{
    //and integer corosponding to the button that will be used to pick up and drop the package
    public int ButtonIndex = 1;

    [SerializeField] private bool isCollected;
    [SerializeField] private bool canCollect;

    private GameObject package; //hij pakt nu altijd deze package

    private float dropOffset = 2.0f;

    void Start()
    {
        canCollect = false;
        isCollected = false;

    }

    void Update()
    {
        /*PackageCollecting();*/
        /*  Debug.Log(isCollected);
          Debug.Log(canCollect);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "package")
        {
            canCollect = true;

            //dit kan zolang we het erbij houden dat we 1 package steeds uit het 'magazijn' meenemen
            package = other.gameObject;

        }
    }

    public void OnButton(int button, bool state)
    {
        PackageCollecting(button, state);
    }

    private void PackageCollecting(int button, bool state)
    {
        if (button == ButtonIndex && canCollect == true && isCollected == false)
        {
            canCollect = false;

            package.transform.position = transform.position;
            package.transform.parent = transform;

            isCollected = true;
        }


        if (button == ButtonIndex && canCollect == false && isCollected == true)
        {
            isCollected = false;

            package.transform.parent = null;
            package.transform.position -= transform.forward * dropOffset;

            canCollect = true;
            package = null;
        }
    }
}
