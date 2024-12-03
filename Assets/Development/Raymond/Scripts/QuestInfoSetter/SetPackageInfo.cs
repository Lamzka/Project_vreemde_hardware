using TMPro;
using UnityEngine;

// This class manages and displays information about the current package quest.
public class SetPackageInfo : MonoBehaviour, ISendCurrentQuestInfo
{
    [Header("Display")]
    [SerializeField] private TMP_Text questDisplay; // Reference to a TextMeshPro text object for displaying quest info.

    [Header("Current Quest Info")]
    [SerializeField] private string currentQuestReciever; // Stores the name of the package receiver.
    [SerializeField] private string currentQuestDestination; // Stores the destination planet for the package.

    private void Start()
    {
        // Finds and assigns the TextMeshPro text component tagged as "DestinationList".
        questDisplay = GameObject.FindGameObjectWithTag("DestinationList").GetComponent<TMP_Text>();

        // Initializes the quest display with a default message indicating no active quest.
        DisplayNewInfo(false);
    }

    private void OnEnable()
    {
        // Registers this object as a listener to the "PackageGrabPoint" for quest updates.
        GameObject.FindGameObjectWithTag("PackageGrabPoint").GetComponent<QuestInfoSubject>().SetListeners(this);
    }

    private void OnDisable()
    {
        // Removes this object as a listener from the "PackageGrabPoint" to stop receiving quest updates.
        GameObject.FindGameObjectWithTag("PackageGrabPoint").GetComponent<QuestInfoSubject>().RemoveListeners(this);
    }

    // Called by the QuestInfoSubject to pass package information to this script.
    public void PackageReceiverInfo(PackageInfo packageInfo)
    {
        // Sets the quest information based on the received package info.
        SetQuesInformation(packageInfo);
    }

    private void SetQuesInformation(PackageInfo packageInfo)
    {
        if (packageInfo == null) // Checks if the package info is null (no package loaded).
        {
            currentQuestReciever = null; // Clears the current receiver info.
            currentQuestDestination = null; // Clears the current destination info.

            DisplayNewInfo(true); // Updates the display to show "No packages loaded."

            // Clears the destination info in the GameManagers component.
            GameObject.FindGameObjectWithTag("GameManagers").GetComponent<ISetDestinationInfo>().SetDestinationName(null);
        }
        else // If valid package info is provided.
        {
            // Randomly selects a receiver name from the package info.
            currentQuestReciever = packageInfo.RecieverName[Random.Range(0, packageInfo.RecieverName.Length)];

            // Randomly selects a destination from the package info.
            currentQuestDestination = packageInfo.RecieverPlanet[Random.Range(0, packageInfo.RecieverPlanet.Length)];

            // Updates the destination info in the GameManagers component.
            GameObject.FindGameObjectWithTag("GameManagers").GetComponent<ISetDestinationInfo>().SetDestinationName(currentQuestDestination);

            DisplayNewInfo(false); // Updates the display with the new quest details.
        }
    }

    private void DisplayNewInfo(bool isNull)
    {
        if (isNull) // If no package is loaded.
        {
            questDisplay.text = "No packages loaded"; // Display a default message.
        }
        else // If a package is loaded.
        {
            // Displays the current receiver and destination information.
            questDisplay.text = "Deliver package to: " + currentQuestReciever + " on " + currentQuestDestination;
        }
    }
}
