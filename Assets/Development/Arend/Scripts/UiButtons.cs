using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButtons : MonoBehaviour
{
   public void MainMenuButton()
    {
        SceneManager.LoadScene("StartMenu");
    }

   public void StartButton()
    {
        SceneManager.LoadScene("Ending");
    }
}
