using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class provaInterruptorPressio : MonoBehaviour
{
    //script que controla els interruptors del terra que fan desapareixer portes activades
    //game object al que li assignarem les portes que s'obrin en questió amb cadascun dels interruptors que col·loquem a les escenes.
    public GameObject Compuerta;
    public bool pressed;
    //sprites als que canviarà (l'inicial es Unpressed i canvia al Pressed) si fa collide amb un objecte movable (funció més abaix)
    public Sprite spriteUnpressed;
    public Sprite spritePressed;
    AudioManager audioManager;
    void Awake()
    {
        //referenciem l'audiomanager per reproduir el so de la porta obrintse
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //pressed sempre començarà en false
        pressed = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteUnpressed;
    }

    // Update is called once per frame
    void Update()
    {
        //en el moment que es presioni, canviarà el sprite i es destruirà el gameobject que haguem serialitzat a l'espai Compuerta de l'inspector de unity
        if (pressed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritePressed;
            Destroy(Compuerta);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Movable"))
        {
            //quan faci collide amb un objecte movable, reproduirem el so i canviarem pressed a true
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