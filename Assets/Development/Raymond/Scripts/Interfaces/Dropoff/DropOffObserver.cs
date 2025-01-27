using System.Collections.Generic;
using UnityEngine;

public class DropOffObserver : MonoBehaviour
{
    private List<IDropOffCheck> observers = new List<IDropOffCheck>();

    public void SetListeners(IDropOffCheck observer)
    {
        observers.Add(observer);
    }

    public void RemoveListeners(IDropOffCheck observer)
    {
        observers.Remove(observer);
    }

    public void CheckDropOff()
    {
        observers.ForEach(observer => observer.CheckDropOff());
    }
}
