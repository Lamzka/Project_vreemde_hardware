using UnityEngine;

public class SoundRelativeToVelocity : MonoBehaviour
{
    [Header("Movement AudioSource")]
    [SerializeField] private AudioSource audioSource;

    [Header("RidgidBody Refrence")]
    [SerializeField] private Rigidbody rigidBody;
    public bool CanFly;

    [Header("Sound threshholds")]
    public float IdleThreshhold;
    public float MovingThreshhold;
    public float SlowingDownThreshhold;

    [Header("AudioClips")]
    public AudioClip Idle;
    public AudioClip Moving;
    public AudioClip SlowingDown;

    [Header("CurrentClip")]
    [SerializeField] private AudioClip currentClip;
    [SerializeField] private AudioClip queuedClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }


    private void Update()
    {

        float currentSpeed = rigidBody.velocity.magnitude;

        switch (currentSpeed, CanFly)
        {

            case ( > -1, false):
                queuedClip = null;
                break;

            case var _ when currentSpeed <= IdleThreshhold && true:
                queuedClip = Idle;
                Debug.Log("Idle");
                break;

            case var _ when currentSpeed >= MovingThreshhold && true:
                queuedClip = Moving;
                Debug.Log("moving");
                break;

            case var _ when currentSpeed <= SlowingDownThreshhold && true:
                queuedClip = SlowingDown;
                Debug.Log("Slowing");
                break;

        }

        if (queuedClip != currentClip || queuedClip != null && currentClip == null)
        {
            PlayClip(queuedClip);
        }


    }

    void PlayClip(AudioClip clip)
    {
        if (/*audioSource.time == audioSource.clip.length ||*/ audioSource.clip == null)
        {
            currentClip = clip;
            audioSource.clip = clip;
            audioSource.Play();
            audioSource.loop = true;
        }


    }


}



