using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Action : MonoBehaviour
{
    public GameObject currentInteractable;
    // Start is called before the first frame update
    void Start()
    {
        
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
            }
        }
    }
}
