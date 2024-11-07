using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuelpoints : Pickup
{
    [SerializeField] private Fueldepletion fuelDepletion;

    public float AddFuelAmount;
    protected override void Activate()
    {
        fuelDepletion.Fuel += AddFuelAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Activate();
            gameObject.SetActive(false);
        }
    }
}
