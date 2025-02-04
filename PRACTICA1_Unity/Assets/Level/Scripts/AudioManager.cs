using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //script que configura els volums dels sons i can�� del joc. Cont� els arxius de sound effects i tamb� controla que la M faci Mute al joc.
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource musicSource;
    public AudioClip background;
    public AudioClip caught;
    public AudioClip keyCollected;
    public AudioClip moneyCollected;
    public AudioClip keyDoorOpen;
    public AudioClip buttonDoorOpen;
    //variable que ajuda a que el joc s�piga si est� en mute o no
    public bool mute = false;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        //necessaris per utilitzar el component d'audio del objecte AudioManager
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = background;
        musicSource.Play();
    }
    void Awake()
    {
        //semblant al gameManager_Variables, aquest codi per la inst�ncia que es crea del audiomanager fa que quan s'activa l'objecte en escena, es mantingui per les posteriors, i els seguents AudioManager que es crein al canviar d'escena no siguin el principal. Aix� ho fem principalment perqu� la m�sica del joc pugui ser continua i en loop, i no hagi de fer resset cada cop que comen�a un nivell
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
            //fem un toggle a la variable Mute abans d'executar els codis dels ifs. En la primera iteraci�, com que mute �s fals, entraria a fer el primer if, i esperarem fins al seguent update de frame per canviar la variable amb el toggle, ja que si ho fessim a dins de cada if, possiblement ens quedariem en bucle entrant en els dos ifs a la vegada per frame i mai tornariem a activar/desactivar el so.
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
