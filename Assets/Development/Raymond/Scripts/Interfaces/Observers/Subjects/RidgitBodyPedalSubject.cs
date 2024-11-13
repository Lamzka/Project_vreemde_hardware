using System.Collections.Generic;
using UnityEngine;

public class RidgitBodyPedalSubject : MonoBehaviour
{
    private List<IRidgidBodyPedals> observers = new List<IRidgidBodyPedals>();

    public void SetListeners(IRidgidBodyPedals observer)
    {
        observers.Add(observer);
    }

    public void RemoveListeners(IRidgidBodyPedals observer)
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
