using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private GameObject destinationMarker;
    [SerializeField] private GameObject package;
    public bool pickedUpPackage;

    void Update()
    {
        if (pickedUpPackage)
        {
            SetMarker();
        }
    }

    private void SetMarker()
    {
        destinationMarker.transform.position = planets[Random.Range(0, planets.Length)].transform.position;
        pickedUpPackage = false;
    }
}
