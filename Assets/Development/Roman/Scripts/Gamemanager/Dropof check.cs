using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dropofcheck : MonoBehaviour
{
    [SerializeField] private TMP_Text correctPlanetText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("package"))
        {
            correctPlanetText.text = "You deliverd the package to the right planet";
        }
        else
        {
            correctPlanetText.text = "";
        }
    }
}
