using System.Collections.Generic;
using UnityEngine;

public class PedalInputSubject : MonoBehaviour
{
    private List<IPedalInput> observers = new List<IPedalInput>();

    public void SetListeners(IPedalInput observer)
    {
        observers.Add(observer);
    }

    public void RemoveListeners(IPedalInput observer)
    {
        observers.Remove(observer);
    }

    public void OnGasPedal(float GasValue)
    {
        observers.ForEach(observer => observer.OnGasPedal(GasValue));
    }

    public void OnBreakPedal(float BreakValue)
    {
        observers.ForEach(observer => observer.OnBreakPedal(BreakValue));
    }
}
