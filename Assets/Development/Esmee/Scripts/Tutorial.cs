using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour, IButtonInput
{
    [SerializeField] private List<GameObject> sprites = new List<GameObject>(); //list with all slides
    [SerializeField] private List<AudioClip> aiVoice = new List<AudioClip>(); //list with all audio clips
    [SerializeField] private AudioSource audioSrc; //audio source
    private int currentSlide = 0; //slides start at the first one

    private int RequestedButton;
    private int currentButtonPressed;

    private bool TaskOngoing;

    private bool isPlaying()
    {
        if (audioSrc.isPlaying)
        {
            return true;
        }
        else 
        {
            return false;
        }   
    }

    private bool buttonRequitementCheck()
    {
        if (currentButtonPressed == RequestedButton)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void Start()
    {
        currentSlide = 0;
        TaskOngoing = false;
        audioSrc.Stop();
    }

    public void OnButton(int button, bool State)
    {
        button = currentButtonPressed;
    }

   

    private void Update()
    {
        if (!TaskOngoing && !isPlaying())
        {
            NextSlide();

            switch (currentSlide)
            {
                case (0): TutorialStart(); break;
                case (1): ascend(); break;
            }
        }

      
    }

    private void playClip()
    {
        audioSrc.clip = aiVoice[currentSlide];
        audioSrc.Play();
    }
    private void NextSlide()
    {
        currentSlide++;
        audioSrc.Stop();
        TaskOngoing = false;
    }


    private void TutorialStart()
    {
        if (!isPlaying())
        playClip();
    }

    private void ascend()
    {
        TaskOngoing = true;
        playClip();
        StartCoroutine(WaitTillButtonPress());
  
    }

    bool test = false;
    IEnumerator WaitTillAudioIsFinished()
    {
        yield return new WaitUntil(isPlaying);
    }

    IEnumerator WaitTillButtonPress()
    {
        yield return new WaitUntil(buttonRequitementCheck);

    }

  

  


    



    /*  IEnumerator NextSlide()
      {
          for (int i = 0; i < sprites.Count; i++) // Loop through all slides
          {
              if (currentSlide >= 0)
              {
                  *//* sprites[currentSlide].SetActive(false); // turn off the last slide*//*
              }

              *//* currentSlide = i;
               sprites[currentSlide].SetActive(true);*//* //activate the next slide

              if (i < aiVoice.Count)
              {
                  audioSrc.clip = aiVoice[i];
                  audioSrc.Play(); //start playing audio

                  while (audioSrc.isPlaying) //waits until the audio is finished playing
                  {
                      yield return null;
                  }
              }

              yield return new WaitForSeconds(3f); //wait a few seconds before the next slide
          }

          SceneManager.LoadScene("MainScene"); //load main scene
      }

  */


    /* public bool buttonpressed;
     private bool audioIsFinished;

     void OnEnable()
     {
         GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().SetListeners(this); //Set this class as a listener to the ButtonInputSubject
     }

     void OnDisable()
     {
         GameObject.FindGameObjectWithTag("InputManagers").GetComponent<ButtonInputSubject>().RemoveListeners(this); //remove this class as a listener to the ButtonInputSubject
     }

     private void Start()
     {
         WelcomePilot();
     }

     public void OnButton(int button, bool State)
     {

         PressX(button);
     }



     private void WelcomePilot()
     {
         sprites[0].SetActive(true);
         audioSrc.clip = aiVoice[0];
         audioSrc.Play();
         StartCoroutine(WaitForAudioToFinish(() => PressX(0)));
     }

     private void PressX(int button)
     {
         sprites[1].SetActive(true);
         audioSrc.clip = aiVoice[1];
         audioSrc.Play();
         if (button == 0 || buttonpressed == true)
         {
             StartCoroutine(WaitForAudioToFinish(() => UseShifter(15)));
         }
     }

     private void UseShifter(int button)
     {
         sprites[2].SetActive(true);
         audioSrc.clip = aiVoice[2];
         audioSrc.Play();
         if (button == 14 || button == 15)
         {
             StartCoroutine(WaitForAudioToFinish(() => SteerWheel()));
         }
     }

     private void SteerWheel()
     {
         sprites[3].SetActive(true);
         audioSrc.clip = aiVoice[3];
         audioSrc.Play();
         StartCoroutine(WaitForAudioToFinish(() => GiveGas()));
     }

     private void GiveGas()
     {
         sprites[4].SetActive(true);
         audioSrc.clip = aiVoice[4];
         audioSrc.Play();
         StartCoroutine(WaitForAudioToFinish(() => GrabPackage(1)));
     }

     private void GrabPackage(int button)
     {
         sprites[5].SetActive(true);
         audioSrc.clip = aiVoice[5];
         audioSrc.Play();
         if (button == 1)
         {
             StartCoroutine(WaitForAudioToFinish(() => ReadyPilot()));
         }
     }

     private void ReadyPilot()
     {
         sprites[6].SetActive(true);
         audioSrc.clip = aiVoice[6];
         audioSrc.Play();
         //wacht paar secs
         SceneManager.LoadScene("MainScene");

     }

     private IEnumerator WaitForAudioToFinish(System.Action callback)
     {
         yield return new WaitUntil(() => !audioSrc.isPlaying);
         callback?.Invoke();
     }*/

}
