using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour, IButtonInput, IWheelInput, IPedalInput
{
    //Serialized Fields
    [SerializeField] private List<GameObject> sprites = new List<GameObject>(); //list with all slides

    [SerializeField] private List<AudioClip> aiVoice = new List<AudioClip>(); //list with all audio clips

    [SerializeField] private AudioSource audioSrc; //audio source

    //Public Fields
    public float RequestedMaxLeftWheelRotation;   //Rotation needed to proceed
    public float RequestedMaxRightWheelRotation;  //Rotation needed to proceed

    public float RequestedGasPedalInput = 50;    //Gas pedal input needed to proceed
    public float RequestedBreakPedalInput = 50;  //Break pedal input needed to proceed

    //Private Fields
    private int currentSlide = 0;     //Slides start at the first one
    private int RequestedButton;      //Button that the player needs to press to proceed
    private int currentButtonPressed; //Button the player is currently pressing
 
    private float currentWheelRotation;   //Current Rotation of the steering wheel
    private float currentGasPedalInput;   //Current Input of the gaspedal
    private float currentBreakPedalInput; //Current Input of the beakpedal

    private bool TaskOngoing = true;   //Is true when Player input is needed

    private bool isNotPlaying()   //Check if the audioSorce is playing a sound
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

    private bool buttonRequitementCheck()   //Checks if player button input is equal to whats requested
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

    private bool isWheelToTheLeft()   //Checks if the wheel is over the requested value
    {
       if(currentWheelRotation > RequestedMaxLeftWheelRotation)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isWheelToTheRight()   //Checks if the wheel is over the requested value
    {
        if (currentWheelRotation > RequestedMaxRightWheelRotation)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isGasPedalPressed()   //Checks if the gas pedal is pressed
    {
        if(currentGasPedalInput > RequestedGasPedalInput)
        {
            return true;
        }
        else
        {
            return false ;
        }
    }

    private bool isBreakPedalPressed()   //Checks if the break pedal is pressed
    {
        if (currentBreakPedalInput > RequestedBreakPedalInput)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnButton(int button, bool State)
    {
        button = currentButtonPressed;
    }

    public void OnWheelInput(float input)
    {
        input = currentWheelRotation;
    }

    public void OnGasPedal(float GasValue)
    {
        GasValue = RequestedGasPedalInput;
    }

    public void OnBreakPedal(float BreakValue)
    {
        BreakValue = RequestedBreakPedalInput;
    }

    private void Start() 
    {
        audioSrc.Stop();
        currentSlide = 0;
        TaskOngoing = false;    
    }

    private void Update()
    {
        if (!TaskOngoing && isNotPlaying())   //if a task is not ongoing and the audioSource is not playing any sound
        {

            switch (currentSlide)   //Switch case to call the functions needed for the current slide 
            {
                case (0): WaitUntilAudioIsFinished(false); break;       //intro
                case (1): WaitForButtonInput(0);  break;                //startup/acend
                case (2): WaitUntilAudioIsFinished(false); break;       //wheel intro
                case (3): WaitForWheelTurn(false); break;               //turn left
                case (4): WaitForWheelTurn(true); break;                //turn right
                case (5): WaitForButtonInput(4); break;                 // wheel triggers
                case (6): WaitTillAudioIsFinished(false); break;        //shifter info
                case (7): WaitForButtonInput(14); break;                //Shifter up
                case (8): WaitForButtonInput(15); break;                //Shifter down
                case (9): WaitUntilAudioIsFinished(false); break;       //Pedal intro
                case (10): WaitForPedals(true); break;                  //Gas pedal
                case (11): WaitForPedals(false); break;                 //Break pedal
                case (12): WaitTillAudioIsFinished(false); break;       //Package grab intro
                case (13): WaitForButtonInput(1); break;                //grab Package
                case (14): WaitForButtonInput(1); break;                //Drop Package
                case (15): WaitUntilAudioIsFinished(true); break;       //Tutorial End
            }
        }

      
    }

    private void playClip()   //Sets and plays an audioclip acording to the slide count
    {
        audioSrc.Stop();
        audioSrc.clip = aiVoice[currentSlide];
        audioSrc.Play();
    }

    private void NextSlide()   //Progresses slides
    {
        currentSlide++;
        TaskOngoing = false;
    }


    private void WaitUntilAudioIsFinished(bool IsTutorialEnd)   //Waits until the audioSource isnt playing any sound and proceeds to next slide
    {
        TaskOngoing = true;

        if (isNotPlaying())
        playClip();

        StartCoroutine(WaitTillAudioIsFinished(IsTutorialEnd));

    }

    private void WaitForButtonInput(int buttonIndex)   //Wait until the player has pressed requested button
    {
        TaskOngoing = true;

        RequestedButton = buttonIndex;

        if (isNotPlaying())
            playClip();

        StartCoroutine(WaitTillButtonPress());
    }

    private void WaitForWheelTurn(bool DirectionSwitch)   //waits untill player has turned the wheel to the left
    {
        TaskOngoing = true;

        if (isNotPlaying())
            playClip();

        StartCoroutine(WaitTillWheelHasTurned(DirectionSwitch));
    }

   
    private void WaitForPedals(bool PedalSwitch)   //waits until the player has pressed requested pedal
    {
        TaskOngoing = true;
        if (isNotPlaying())
            playClip();

        StartCoroutine(WaitTillPedalsArePressed(PedalSwitch));
    }



    //true = Change to main Scene
    //false = Change to next slide
    IEnumerator WaitTillAudioIsFinished(bool IsTutorialEnd)   
    {
        yield return new WaitUntil(isNotPlaying);

        if (IsTutorialEnd)
        {
            SceneManager.LoadScene("MainScene");
        }
        else if (!IsTutorialEnd)
        {
            NextSlide();
            TaskOngoing = false;
        }   
    }

    IEnumerator WaitTillButtonPress()
    {
        yield return new WaitUntil(buttonRequitementCheck);
        NextSlide();
        TaskOngoing = false;

    }


    //true = Right
    //false = Left
    IEnumerator WaitTillWheelHasTurned(bool DirectionSwitch)
    {

        if (DirectionSwitch)
        {
            yield return new WaitUntil(isWheelToTheRight);
        }
        else if (!DirectionSwitch)
        {  
            yield return new WaitUntil(isWheelToTheLeft);
        }
        
        NextSlide();
        TaskOngoing = false;
    }

    //true = GasPedal
    //false = BreakPedal
    IEnumerator WaitTillPedalsArePressed(bool PedalSwitch)
    {
        if (PedalSwitch)
        {
            yield return new WaitUntil(isGasPedalPressed);
        }
        else if (!PedalSwitch)
        {
            yield return new WaitUntil(isBreakPedalPressed);
        }

        NextSlide();
        TaskOngoing = false;
    }

}
