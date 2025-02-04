using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class provaInterruptorPressio : MonoBehaviour
{
    public GameObject Compuerta;
    public bool pressed;
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
        //hasActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            //acció quan es pulsa el botó amb moble
            //hasActivated = true;
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