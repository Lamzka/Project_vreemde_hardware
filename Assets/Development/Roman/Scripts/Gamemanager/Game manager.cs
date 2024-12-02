using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private GameObject destinationMarker;
    [SerializeField] private GameObject package;
    [SerializeField] private GameObject packagePickupLocation;
    [SerializeField] private GrabAndDrop grabAndDrop;
    public bool PickedUpPackage;
    public bool DeliveredPackage;

    void Update()
    {
        if (grabAndDrop.isCollected == true)
        {
            PickedUpPackage = true;
        }
        if (PickedUpPackage)
        {
            SetMarker();
        }

        if (DeliveredPackage)
        {
            DeliverdPackage();
        }
    }

    private void SetMarker()
    {
        destinationMarker.transform.position = planets[Random.Range(0, planets.Length)].transform.position;
        PickedUpPackage = false;
    }

    private void DeliverdPackage()
    {
        destinationMarker.transform.position = packagePickupLocation.transform.position;
        DeliveredPackage = false;
    }
}
