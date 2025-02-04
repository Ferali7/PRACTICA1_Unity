using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cajaFuerte_Script : MonoBehaviour
{
    public bool collapsed;
    Animator animator;
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
        //Destroy(gameObject);
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