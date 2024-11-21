using System.Collections;
using TMPro;
using UnityEngine;

public class Fueldepletion : MonoBehaviour
{
    [SerializeField] private TMP_Text fuelText;
    [SerializeField] private GameObject sosCanvas;
    public float Fuel;

    [SerializeField] private GameObject bigShip;
    public bool xButtonPressed;

    [SerializeField] private GameObject sphere;


    void Update()
    {
        FuelDropping();
    }

    private void FuelDropping()
    {
        if (Fuel >= 0)
        {
            Fuel -= Time.deltaTime;
        }

        fuelText.text = Fuel.ToString("F0") + "%";
        NoFuelLeft();
    }

    private void NoFuelLeft()
    {
        if (Fuel <= 0.01)
        {
            sosCanvas.SetActive(true);
            if (xButtonPressed)
            {
                StartCoroutine(FadeIn());
                StartCoroutine(WaitASec());
            }
        }
    }

    IEnumerator FadeIn()
    {
        Renderer rend = sphere.transform.GetComponent<Renderer>();

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            rend.material.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        Renderer rend = sphere.transform.GetComponent<Renderer>();

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            rend.material.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    IEnumerator WaitASec()
    {
        sosCanvas.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        transform.position = bigShip.transform.position;
        StartCoroutine(FadeOut());
        Fuel = 100;
    }

}
