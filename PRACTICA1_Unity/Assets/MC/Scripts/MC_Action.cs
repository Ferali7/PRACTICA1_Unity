using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_Action : MonoBehaviour
{
    public GameObject currentInteractable;
    /*public GameObject EKEY;
    public eKeyUIControl eKeyUIControl;
    private Vector2 displace = new Vector2(1, 1);
    public bool showE;
    public Vector2 newPositionE = new Vector2();*/
    // Start is called before the first frame update
    void Start()
    {
        /*eKeyUIControl = GameObject.Find("EKEY").GetComponent<eKeyUIControl>();
        if (eKeyUIControl != null)
        {
            print("ekeyUICONTROL is missing!!");
        }
        eKeyUIControl = GetComponent<eKeyUIControl>();
        showE = false;*/
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
            //
            //mostrar la E Key a sobre de l'objecte i dirli que la seva posici� �s la posici� de la camara + un offset o displace de (1,1)
            //Vector2 newPositionE = eKeyUIControl.posicioE((Vector2)transform.position + displace);
            //showE = true;
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
                //showE = false;
            }
        }
    }
}