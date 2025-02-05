using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //per tal de poder controlar la llum i els seus colors, s'ha d'afegir aquesta linia
public class EnemyDetection : MonoBehaviour
{
    //Aquest script esta unica i exclusivament dedicat a que els enemics puguin detectar al jugador, llavors tots els enemics el porten
    //Aqui declaro totes les variables necessaries
    public GameManager_Script GameManager;
    private GameObject player;

    //Aquestes dues variables son per comprobar si el jugador esta a la "vista", una mira si es troba dins la trigger box de la lot i l'altre si no hi ha cap objecte entre mig el jugador i l'enemic

    private bool InSight;
    private bool InLight = false;


    AudioManager audioManager;
    public Light2D myLight;

    void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); //Aqui crido al audio manager per despres poder utilitzar els sons del prefab
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //troba al jugador
        GameManager = GameObject.FindObjectOfType<GameManager_Script>();
    }
    IEnumerator caughtDelay() //Funció que no fa que sigui inmediata la pantalla de "has perdut", potser podem fer que el joc es pari hi hagi una petita animació abans (?)
    {
        yield return new WaitForSeconds(2.0f);
        GameManager.caught = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InLight = false;
        }
    }

    //Per com esta fet el nostre joc, no podem fer que la detecció funcioni només a través d'una Trigger Box, ja que al haver objectes entre mig, un jugador podria estar rere una llibreria "ocult"
    //i encara així seria detectat per la naturalesa d'una TriggerBox, per tant va pensar en fer d'alguna manera en que controles si esta dins la trigger box i sense cap objecte entre mig
    //La solucio va ser aprendre a utilitzar Raycast, cosa que ens permet poder detectar si hi ha un objecte entre mig o fins i tot fer que alguns objectes puguis veure a través d'ells
    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            InSight = ray.collider.CompareTag("Player");

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Comprova si el jugador es troba dins la llum
        {
            InLight = true;
            if (InSight && InLight) //es compleixen les dues condicions?
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                print("Detected!!");
                audioManager.PlaySFX(audioManager.caught);
                myLight.color = new Color(255, 0, 0, 50f);
                myLight.falloffIntensity = 0f;
                myLight.shapeLightFalloffSize = 0f;
                //GameManager.caught = true;
                //StartCoroutine(caughtDelay());
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }

}
