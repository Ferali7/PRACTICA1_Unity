using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cajaFuerte_Script : MonoBehaviour
{
    //script de la caixa forta, molt similar als pickups de clau que s'activen amb la E quan fa collapse amb el tag "Player". en aquest cas, activarà el salt a l'escena "END_Victory".
    public bool collapsed;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        collapsed = false;
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
        gameObject.tag = "Interacted";
        //audioManager.PlaySFX(audioManager.keyCollected);
        SceneManager.LoadScene("END_Victory");
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