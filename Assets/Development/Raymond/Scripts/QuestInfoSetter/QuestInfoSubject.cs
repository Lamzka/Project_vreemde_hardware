using System.Collections.Generic;
using UnityEngine;

public class QuestInfoSubject : MonoBehaviour
{
    private List<ISendCurrentQuestInfo> observers = new List<ISendCurrentQuestInfo>();

    public void SetListeners(ISendCurrentQuestInfo observer)
    {
        observers.Add(observer);
    }

    public void RemoveListeners(ISendCurrentQuestInfo observer)
    {
        observers.Remove(observer);
    }

    public void OnSecurePackage(PackageInfo packageInfo)
    {
        observers.ForEach(observer => observer.PackageReceiverInfo(packageInfo));
    }


}
