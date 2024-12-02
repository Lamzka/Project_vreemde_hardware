using TMPro;
using UnityEngine;

public class SetPackageInfo : MonoBehaviour, ISendCurrentQuestInfo
{

    [Header("Display")]
    [SerializeField] private TMP_Text QuestDisplay;

    [Header("Current Quest Info")]
    [SerializeField] private string CurrentQuestReciever;
    [SerializeField] private string CurrentQuestDestination;

    private void Start()
    {
        QuestDisplay = GameObject.FindGameObjectWithTag("DestinationList").GetComponent<TMP_Text>();
        DisplayNewInfo(false);
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("PackageGrabPoint").GetComponent<QuestInfoSubject>().SetListeners(this);
    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("PackageGrabPoint").GetComponent<QuestInfoSubject>().RemoveListeners(this);
    }

    public void PackageReceiverInfo(PackageInfo packageInfo)
    {
        SetQuesInformation(packageInfo);
    }

    private void SetQuesInformation(PackageInfo packageInfo)
    {
        if (packageInfo == null)
        {
            CurrentQuestReciever = null;

            CurrentQuestReciever = null;

            DisplayNewInfo(true);

        }
        else
        {
            CurrentQuestReciever = packageInfo.RecieverName[Random.Range(0, 10)];
            CurrentQuestDestination = packageInfo.RecieverPlanet[Random.Range(0, 10)];
            DisplayNewInfo(false);
        }
    }

    private void DisplayNewInfo(bool isNull)
    {
        if (isNull)
        {
            QuestDisplay.text = "No packages loaded";
        }
        else
        {
            QuestDisplay.text = "Deliver package to: " + CurrentQuestReciever + " on " + CurrentQuestDestination;
        }

    }

}
