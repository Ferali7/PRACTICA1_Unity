using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provaObject : MonoBehaviour
{
    //script que controla les claus de l'escena i com aquestes permeten sumar a la variable Keys
    public GameManager_V_Script gameManagerV;
    public bool collapsed;
    Animator animator;
    Rigidbody2D rb;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Start()
    {
        //trobem el gamemanager_Variables a l'escena
        gameManagerV = FindObjectOfType<GameManager_V_Script>();
        collapsed = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collapsed && Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }
    //en interactuar amb la clau, reproduirem un so, afegirem 1 clau a la quantitat total i destruirem el gameObject
    public void OnInteract()
    {
        audioManager.PlaySFX(audioManager.keyCollected);
        gameManagerV.AddKey();
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