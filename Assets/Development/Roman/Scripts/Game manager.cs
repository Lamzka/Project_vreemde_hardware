using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private Transform[] planets;
    [SerializeField] private GameObject destinationMarker;
    [SerializeField] private GameObject package;
    [SerializeField] private bool pickedUpPackage;
    [SerializeField] private bool ifDroped;

    void Update()
    {
        if (pickedUpPackage)
        {
            SetMarker();
        }
        if (ifDroped)
        {
            DropofCheck();
        }
    }

    private void SetMarker()
    {
        destinationMarker.transform.position = planets[Random.Range(0, planets.Length)].position;
        pickedUpPackage = false;
    }

    private void DropofCheck()
    {
        if (package.transform.position != destinationMarker.transform.position)
        {
            Debug.Log("Wrong planet");
        }
        else
        {
            Debug.Log("Right planet");
        }
    }
}
