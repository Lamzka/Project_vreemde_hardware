using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour, IButtonInput, IWheelInput
{
    [SerializeField] private List<GameObject> sprites = new List<GameObject>(); //list with all slides
    [SerializeField] private List<AudioClip> aiVoice = new List<AudioClip>(); //list with all audio clips
    [SerializeField] private AudioSource audioSrc; //audio source
    private int currentSlide = 0; //slides start at the first one

    private int RequestedButton;
    private int currentButtonPressed;

    private bool TaskOngoing = true;

    private float currentWheelRotation;

    private bool isNotPlaying()
    {
        if (audioSrc.isPlaying)
        {
            return false;
        }
        else 
        {
            return true;
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

    private bool isWheelToTheLeft()
    {
       if(currentWheelRotation > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isWheelToTheRight()
    {
        if (currentWheelRotation > 0)
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
        audioSrc.Stop();
        currentSlide = 0;
        TaskOngoing = false;    
    }

    public void OnButton(int button, bool State)
    {
        button = currentButtonPressed;
    }

    public void OnWheelInput(float input)
    {
        input = currentWheelRotation;
    }



    private void Update()
    {
        if (!TaskOngoing && isNotPlaying())
        {

            switch (currentSlide)
            {
                case (0): TutorialStart(); break;
                case (1): Ascend(); break;
            }
        }

      
    }

    private void playClip()
    {
        audioSrc.Stop();
        audioSrc.clip = aiVoice[currentSlide];
        audioSrc.Play();
    }
    private void NextSlide()
    {
        currentSlide++;
        TaskOngoing = false;
    }


    private void TutorialStart()
    {
        TaskOngoing = true;

        if (isNotPlaying())
        playClip();

        StartCoroutine(WaitTillAudioIsFinished());
    }

    private void Ascend()
    {
        TaskOngoing = true;

        if (isNotPlaying())
            playClip();

        StartCoroutine(WaitTillButtonPress());
    }

    private void TurnToLeft()
    {

    }

   
    IEnumerator WaitTillAudioIsFinished()
    {
        yield return new WaitUntil(isNotPlaying);
        NextSlide();
        TaskOngoing = false;
    }

    IEnumerator WaitTillButtonPress()
    {
        yield return new WaitUntil(buttonRequitementCheck);
        NextSlide();
        TaskOngoing = false;

    }

    IEnumerator WaitTillWheelHasTurnedLeft()
    {
        yield return new WaitUntil(isWheelToTheLeft);
        NextSlide();
        TaskOngoing = false;
    }

    IEnumerator WaitTillWheelHasTurnedRight()
    {
        yield return new WaitUntil(isWheelToTheLeft);
        NextSlide();
        TaskOngoing = false;
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
