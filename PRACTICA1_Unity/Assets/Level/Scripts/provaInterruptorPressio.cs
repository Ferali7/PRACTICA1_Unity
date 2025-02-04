using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class provaInterruptorPressio : MonoBehaviour
{

    public GameObject Compuerta;
    public bool pressed;
    public Sprite spriteUnpressed;
    public Sprite spritePressed;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    //public bool hasActivated;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteUnpressed;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            //acci� quan es pulsa el bot� amb moble
            gameObject.GetComponent<SpriteRenderer>().sprite = spritePressed;
            Destroy(Compuerta);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Movable"))
        {
            audioManager.PlaySFX(audioManager.buttonDoorOpen);
            print("Boton Presionado!!");
            pressed = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        pressed = false;
    }
}