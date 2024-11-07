using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fueldepletion : MonoBehaviour
{
    public float Fuel;

    void Update()
    {
        Fuel -= Time.deltaTime;
    }
}
