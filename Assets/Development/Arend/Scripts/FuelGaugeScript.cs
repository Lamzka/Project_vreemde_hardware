using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGaugeScript : MonoBehaviour
{
    private float fuel;
   public List<GameObject> fuelPoints = new List<GameObject>();

    void Start()
    {
        fuel = GetComponent<Fueldepletion>().Fuel;
    }

 
    void Update()
    {
        GoodFuelGauge();
        fuel = GetComponent<Fueldepletion>().Fuel;
    }

  

    private void GoodFuelGauge()
    {
        if (fuel < 5)
        {
            fuelPoints[0].SetActive(false);
        }
        else
        {
            fuelPoints[0].SetActive(true);
        }

        if (fuel < 10)
        {
            fuelPoints[1].SetActive(false);
        }
        else
        {
            fuelPoints[1].SetActive(true);
        }

        if (fuel < 15)
        {
            fuelPoints[2].SetActive(false);
        }
        else
        {
            fuelPoints[2].SetActive(true);
        }

        if (fuel < 20)
        {
            fuelPoints[3].SetActive(false);
        }
        else
        {
            fuelPoints[3].SetActive(true);
        }

        if (fuel < 25)
        {
            fuelPoints[4].SetActive(false);
        }
        else
        {
            fuelPoints[4].SetActive(true);
        }

        if (fuel < 30)
        {
            fuelPoints[5].SetActive(false);
        }
        else
        {
            fuelPoints[5].SetActive(true);
        }

        if (fuel < 35)
        {
            fuelPoints[6].SetActive(false);
        }
        else
        {
            fuelPoints[6].SetActive(true);
        }

        if (fuel < 38)
        {
            fuelPoints[7].SetActive(false);
        }
        else
        {
            fuelPoints[7].SetActive(true);
        }

        if (fuel < 40)
        {
            fuelPoints[8].SetActive(false);
        }
        else
        {
            fuelPoints[8].SetActive(true);
        }

        if (fuel < 45)
        {
            fuelPoints[9].SetActive(false);
        }
        else
        {
            fuelPoints[9].SetActive(true);
        }

        if (fuel < 50)
        {
            fuelPoints[10].SetActive(false);
        }
        else
        {
            fuelPoints[10].SetActive(true);
        }

        if (fuel < 55)
        {
            fuelPoints[11].SetActive(false);
        }
        else
        {
            fuelPoints[11].SetActive(true);
        }

        if (fuel < 60)
        {
            fuelPoints[12].SetActive(false);
        }
        else
        {
            fuelPoints[12].SetActive(true);
        }

        if (fuel < 65)
        {
            fuelPoints[13].SetActive(false);
        }
        else
        {
            fuelPoints[13].SetActive(true);
        }

        if (fuel < 70)
        {
            fuelPoints[14].SetActive(false);
        }
        else
        {
            fuelPoints[14].SetActive(true);
        }

        if (fuel < 73)
        {
            fuelPoints[15].SetActive(false);
        }
        else
        {
            fuelPoints[15].SetActive(true);
        }

        if (fuel < 75)
        {
            fuelPoints[16].SetActive(false);
        }
        else
        {
            fuelPoints[16].SetActive(true);
        }

        if (fuel < 80)
        {
            fuelPoints[17].SetActive(false);
        }
        else
        {
            fuelPoints[17].SetActive(true);
        }

        if (fuel < 85)
        {
            fuelPoints[18].SetActive(false);
        }
        else
        {
            fuelPoints[18].SetActive(true);
        }

        if (fuel < 90)
        {
            fuelPoints[19].SetActive(false);
        }
        else
        {
            fuelPoints[19].SetActive(true);
        }

        if (fuel < 95)
        {
            fuelPoints[20].SetActive(false);
        }
        else
        {
            fuelPoints[20].SetActive(true);
        }

        if (fuel <= 99)
        {
            fuelPoints[21].SetActive(false);
        }
        else
        {
            fuelPoints[21].SetActive(true);
        }

    }
}
