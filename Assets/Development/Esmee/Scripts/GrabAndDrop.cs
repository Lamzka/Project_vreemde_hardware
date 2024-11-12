using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    private bool canCollect;
    private bool collected;
    private bool foundPackage;
    private GameObject package; //hij pakt nu altijd deze package

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
            package = other.gameObject;
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
            canCollect = true;
            collected = false;
            foundPackage = true;
            package = null; //hij gaat wel op null maar collide meteen weer opnieuw met de oude package
        }
    }
}
