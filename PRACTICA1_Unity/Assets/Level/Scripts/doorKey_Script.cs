using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorKey_Script : MonoBehaviour
{
    //script que controla el comportament de les portes activades amb clau
    //referència al script de variables
    public GameManager_V_Script gameManagerV;
    public bool collapsed;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        //trobar audioManager a l'escena
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        //trobar gameManager variables a l'escena
        gameManagerV = FindObjectOfType<GameManager_V_Script>();
        collapsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //si el jugador ha fet collapse (la funció està a sota) i s'apreta la E I TAMBÉ les claus són un número superior a 0, restarem una clau i activarem OnInteract, que destrueix la porta i fa un soroll.
        if (collapsed && Input.GetKeyDown(KeyCode.E) && gameManagerV.numberKeys > 0)
        {
            gameManagerV.numberKeys--;
            OnInteract();
        }
    }
    public void OnInteract()
    {
        audioManager.PlaySFX(audioManager.buttonDoorOpen);
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collapsed = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        collapsed = false;
    }
}