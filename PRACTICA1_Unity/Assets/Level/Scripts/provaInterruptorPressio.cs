using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provaInterruptorPressio : MonoBehaviour
{
    public GameObject Compuerta;
    public bool pressed;
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
            //acci� quan es pulsa el bot� amb moble
            //hasActivated = true;
            //play sound???
            Destroy(Compuerta);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Movable"))
        {
            print("Boton Presionado!!");
            pressed = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        pressed = false;
    }
}