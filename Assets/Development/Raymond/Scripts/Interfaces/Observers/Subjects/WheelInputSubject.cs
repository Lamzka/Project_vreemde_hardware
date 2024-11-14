using System.Collections.Generic;
using UnityEngine;

public class WheelInputSubject : MonoBehaviour
{
    private List<IWheelInput> observers = new List<IWheelInput>();

    public void SetListeners(IWheelInput observer)
    {
        observers.Add(observer);
    }

    public void RemoveListeners(IWheelInput observer)
    {
        observers.Remove(observer);
    }

    public void OnWheelInput(float input)
    {
        observers.ForEach(observer => observer.OnWheelInput(input));
    }
}
