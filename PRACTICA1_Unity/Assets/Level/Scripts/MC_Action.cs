using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_Action : MonoBehaviour
{
    //per saber que hi ha objecte interactuable al costat
    public GameObject currentInteractable;
    //variable que controla si es mostra o no la tecla E a l'interficie
    public bool showE;
    
    // Start is called before the first frame update
    void Start()
    {
        showE = false;
    }

    // Update is called once per frame
    void Update()
    {
        //si hi ha objecte interactuable al costat, i aquest es del tag diferent a "interactable", amagarem la tecla E de l'interfície
        if (currentInteractable != null && currentInteractable.tag != "Interactable")
        {
            currentInteractable = null;
            showE = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            currentInteractable = collision.gameObject;
            //mostrar la Tecla E a sobre del personatge si fa collision amb objecte de tag "Interactable"
            showE = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            if(currentInteractable == collision.gameObject)
            {
                //tornem la variable de objecte interactuat Nula, aixi sabem que hem d'amagar la tecla E
                currentInteractable = null;
                showE = false;
            }
        }
    }
}