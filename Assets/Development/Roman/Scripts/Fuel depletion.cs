using TMPro;
using UnityEngine;

public class Fueldepletion : MonoBehaviour
{
    [SerializeField] private TMP_Text fuelText;
    [SerializeField] private GameObject sosCanvas;
    public float Fuel;

    void Update()
    {
        fuelDropping();
    }

    private void fuelDropping()
    {
        if (Fuel >= 0)
        {
            Fuel -= Time.deltaTime;
        }

        fuelText.text = Fuel.ToString("F0") + "%";
        noFuelLeft();
    }

    private void noFuelLeft()
    {
        if (Fuel <= 0.01)
        {
            Fuel = 0;
            sosCanvas.SetActive(true);
            //returning to base in 3..2..1..
            //tp naar bigshipinc
            //verlies geld door package damage?
            //ga verder
        }
    }
}
