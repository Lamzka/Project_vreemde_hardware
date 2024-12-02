using TMPro;
using UnityEngine;

public class Dropofcheck : MonoBehaviour
{
    [SerializeField] private TMP_Text correctPlanetText;
    [SerializeField] private Gamemanager gamemanager;

    [SerializeField] private PackageQuestHandler packageQuestHandler;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("package"))
        {
            packageQuestHandler.AddPoint();

            correctPlanetText.text = "You deliverd the package to the right planet";
            gamemanager.DeliveredPackage = true;
        }
        else
        {
            correctPlanetText.text = "";
        }
    }
}
