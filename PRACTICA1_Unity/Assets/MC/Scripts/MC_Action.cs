using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_Action : MonoBehaviour
{
    public GameObject currentInteractable;
    public bool showE;
    
    // Start is called before the first frame update
    void Start()
    {
        showE = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            print("Interacted with: " + currentInteractable.name);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            currentInteractable = collision.gameObject;
            print("Interactable entered: " + currentInteractable.name);
            //mostrar la E Key a sobre de l'objecte i dirli que la seva posició és la posició de la camara + un offset o displace de (1,1)
            showE = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            if(currentInteractable == collision.gameObject)
            {
                currentInteractable = null;
                print("Interactable exited: " + collision.gameObject.name);
                showE = false;
            }
        }
    }
}