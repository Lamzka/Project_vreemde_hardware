using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles the tracking and display of delivered packages and transitions the scene when all packages are delivered.
public class PackageQuestHandler : MonoBehaviour
{
    // Static variable to keep track of the total number of delivered packages across instances.
    public static int PackagesDeliverd = 0;

    [SerializeField] private TMP_Text pakcageCountText; // UI text element to display the delivery status.

    private void Start()
    {
        // Initializes the package count display at the start of the game or scene.
        pakcageCountText.text = "Packages to Deliver: " + PackagesDeliverd + "/4";
    }

    // Increases the package delivery count and updates the display.
    public void AddPoint()
    {
        PackagesDeliverd++; // Increment the total number of delivered packages.
        pakcageCountText.text = "Packages to Deliver: " + PackagesDeliverd + "/4"; // Update the UI.

        // Check if all 4 packages are delivered.
        if (PackagesDeliverd >= 4)
        {
            // Load scene with build index 3 (assumes this is the "mission complete" or next scene).
            SceneManager.LoadScene(3);
        }
    }
}
