using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour, IButtonInput
{
    void Start()
    {

    }
    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().SetListeners(this); //input
    }

    void OnDisable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().RemoveListeners(this); //input
    }

    void Update()
    {

    }

    IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(2f);
    }


    public void OnButton(int button, bool state) //input
    {
        Next(button);
    }

    private void Next(int button)
    {
        if (button == 0)
        {

        }
    }
}
