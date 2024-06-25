using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;    

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("AudioClip")]
    public AudioClip background;
    public AudioClip KillEnemy;
    public AudioClip a;
    public AudioClip b;
    public AudioClip c;
    public AudioClip d;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}