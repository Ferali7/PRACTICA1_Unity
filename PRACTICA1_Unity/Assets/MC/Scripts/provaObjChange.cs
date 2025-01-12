using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class provaObjChange : MonoBehaviour
{
    public bool collapsed;
    public Sprite closed;
    public Sprite open;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        collapsed = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = closed;
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
    public void OnInteract()
    {
        //interacció amb un objecte que canvia com un cofre, es poden afegir més accions a part del canvi de sprite com afegir clau. NOMES ENTRA A FUNCIO SI ESTA FENT COLLISION AMB PLAYER
        print("Interacted with " + gameObject.name);
        if (Input.GetKeyDown(KeyCode.E))
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
