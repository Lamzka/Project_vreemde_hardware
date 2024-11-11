using System.Collections.Generic;
using UnityEngine;

public abstract class RidgitbodyButtonSubject : MonoBehaviour
{

    private List<IRidgidBodyButtons> observers = new List<IRidgidBodyButtons>();

    public void SetListeners(IRidgidBodyButtons observer)
    {
        observers.Add(observer);
    }

    public void RemoveListeners(IRidgidBodyButtons observer)
    {
        observers.Remove(observer);
    }

    public void OnNotify(int button)
    {
        observers.ForEach(observer => observer.OnNotify(button));
    }
}
