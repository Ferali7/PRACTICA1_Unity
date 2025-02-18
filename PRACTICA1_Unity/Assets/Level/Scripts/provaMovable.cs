using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provaMovable : MonoBehaviour
{
    //script per controlar el comportament dels objectes m�bils com les prestatgeries de llibres
    public bool collapsed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        collapsed = false;
        rb = GetComponent<Rigidbody2D>();
        //Definim el rigidbody de l'objecte inicialment com tipus static (�s a dir, imm�bil)
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        //en el cas de fer collide amb el jugador i estar rebent input CONTINU de la lletra E, entrarem a interactuar, i sin�, seguir� en static
        if (collapsed && Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    public void OnInteract()
    {
        //print("Interacted with " + gameObject.name);
        //canviar el tipus de RB a dynamic, i poder empenyar-lo
        rb.bodyType = RigidbodyType2D.Dynamic;
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
