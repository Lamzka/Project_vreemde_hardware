using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> sprites = new List<GameObject>(); //list with all slides
    [SerializeField] private List<AudioClip> aiVoice = new List<AudioClip>(); //list with all audio clips
    [SerializeField] private AudioSource audioSrc; //audio source
    private int currentSlide = 0; //slides start at the first one

    void Start()
    {
        StartCoroutine(NextSlide());
    }

    IEnumerator NextSlide()
    {
        for (int i = 0; i < sprites.Count; i++) // Loop through all slides
        {
            if (currentSlide >= 0)
            {
                sprites[currentSlide].SetActive(false); // turn off the last slide
            }

            currentSlide = i;
            sprites[currentSlide].SetActive(true); //activate the next slide

            if (i < aiVoice.Count)
            {
                audioSrc.clip = aiVoice[i];
                audioSrc.Play(); //start playing audio

                while (audioSrc.isPlaying) //waits until the audio is finished playing
                {
                    yield return null;
                }
            }

            yield return new WaitForSeconds(2f); //wait 2 seconds before the next slide
        }

        SceneManager.LoadScene("MainScene"); //load main scene
    }



}
