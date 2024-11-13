using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    private bool canCollect;
    private bool collected;
    private bool foundPackage;
    private GameObject package; //hij pakt nu altijd deze package
    private float dropOffset = 2.0f;

    void Start()
    {
        canCollect = false;
        collected = false;
        foundPackage = true;
    }

    void Update()
    {
        PackageCollecting();
        Debug.Log(canCollect);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "package" && foundPackage == true)
        {
            canCollect = true;
            package = other.gameObject; //dit kan zolang we het erbij houden dat we 1 package steeds uit het 'magazijn' meenemen
            foundPackage = false;
        }
    }

    private void PackageCollecting()
    {
        if (canCollect == true && foundPackage == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canCollect = false;
                package.transform.position = transform.position;
                package.transform.parent = transform;
                collected = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && collected == true)
        {
            package.transform.parent = null;
            package.transform.position -= transform.forward * dropOffset;
            canCollect = true;
            collected = false;
            foundPackage = true;
            package = null; //hij gaat wel op null maar collide meteen weer opnieuw met de oude package
        }
    }
}
