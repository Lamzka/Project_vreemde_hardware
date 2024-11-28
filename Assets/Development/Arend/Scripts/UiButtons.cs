using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButtons : MonoBehaviour, IButtonInput
{

    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().SetListeners(this);
    }

    void OnDisable()
    {
        GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().RemoveListeners(this);
    }

    public void OnButton(int Button, bool state)
    {
        MainMenuButton(Button);
    }
    private void MainMenuButton(int Button)
    {
        if (Button == 0)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
