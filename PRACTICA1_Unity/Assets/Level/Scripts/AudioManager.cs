using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource musicSource;
    public AudioClip background;
    public AudioClip caught;
    public AudioClip keyCollected;
    public AudioClip moneyCollected;
    public AudioClip keyDoorOpen;
    public AudioClip buttonDoorOpen;
    public bool mute = false;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = background;
        musicSource.Play();
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mute = !mute;
            if (!mute)
            {
                sfxSource.volume = 0.2f;
                musicSource.volume = 0.15f;
            }
            if (mute)
            {
                sfxSource.volume = 0f;
                musicSource.volume = 0.0f;
            }
        }
    }

    // Update is called once per frame
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
