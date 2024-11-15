using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonInputSubject : MonoBehaviour
{

    private List<IButtonInput> observers = new List<IButtonInput>();

    public void SetListeners(IButtonInput observer)
    {
        observers.Add(observer);
    }

    public void RemoveListeners(IButtonInput observer)
    {
        observers.Remove(observer);
    }

    public void OnNotify(int button)
    {
        observers.ForEach(observer => observer.OnButton(button));
    }
}
