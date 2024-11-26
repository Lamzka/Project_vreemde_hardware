using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> sprites = new List<GameObject>();
    [SerializeField] private List<AudioClip> aiVoice = new List<AudioClip>();
    private int currentIndex = -1;

    void Start()
    {
        StartCoroutine(ShowNextImg());
    }

    void Update()
    {

    }

    IEnumerator ShowNextImg()
    {
        while (currentIndex < sprites.Count)
        {
            if (currentIndex >= 0 && currentIndex < sprites.Count)
            {
                sprites[currentIndex].SetActive(false);
            }

            currentIndex++;

            if (currentIndex < sprites.Count)
            {
                sprites[currentIndex].SetActive(true);
                //aiVoice.Play();
            }

            yield return new WaitForSeconds(10);

        }

        SceneManager.LoadScene("MainScene");
    }
}
