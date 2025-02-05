using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class provaObjChange : MonoBehaviour
{
    //script que controla els objectes que canvien de sprite com la caixa forta al ser oberta i després robada
    public GameManager_V_Script gameManagerV;
    public bool collapsed;
    //els diferents sprites pels que canviarà
    public Sprite closed;
    public Sprite open;
    public Sprite stolen;
    Rigidbody2D rb;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        //trobem a l'escena el gamemanager_variables per poder sumar diners després de recollirlos de la caixa forta
        gameManagerV = FindObjectOfType<GameManager_V_Script>();
        collapsed = false;
        //inicialitzem amb el sprite de Tancada
        this.gameObject.GetComponent<SpriteRenderer>().sprite = closed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //si es fa collide i es pulsa E, interactuem
        if (collapsed && Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }
    public void OnInteract()
    {
        //la funció, de primeres, entrarà al segon if, ja que el sprite encara no és open, és closed. Entrarem al segon i en interactuar amb la E canviarem el sprite a OPEN. Ara, ens seguirà apareixent la E a sobre del personatge, i si tornem a pulsar ara sí que entrarem al primer IF. El polsem, sumem diners al script gamemanager_variables, reproduim so i canviem el sprite a ROBAT. A part, canviem el tag a Interacted, així treiem la E de sobre del jugador ja que ja no pot interactuar
        if (gameObject.GetComponent<SpriteRenderer>().sprite == open)
        {
            gameManagerV.AddMoney();
            audioManager.PlaySFX(audioManager.moneyCollected);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = stolen;
            gameObject.tag = "Interacted";
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite == closed)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = open;
        }
        
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
