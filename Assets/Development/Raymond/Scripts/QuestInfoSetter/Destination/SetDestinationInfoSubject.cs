using System.Collections.Generic;
using UnityEngine;

public class SetDestinationInfoSubject : MonoBehaviour
{
    private List<ISetDestinationInfo> observers = new List<ISetDestinationInfo>();

    public void SetListeners(ISetDestinationInfo observer)
    {
        observers.Add(observer);
    }

    public void RemoveListeners(ISetDestinationInfo observer)
    {
        observers.Remove(observer);
    }

    public void OnSecurePackage(string DestinationName)
    {
        observers.ForEach(observer => observer.SetDestinationName(DestinationName));
    }


}
