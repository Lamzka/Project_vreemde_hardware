using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fueldepletion : MonoBehaviour
{
    [SerializeField] private TMP_Text fuelText;
    public float Fuel;

    void Update()
    {
        if (Fuel >= 0)
        {
            Fuel -= Time.deltaTime;
        }

        fuelText.text = Fuel.ToString();
    }
}
