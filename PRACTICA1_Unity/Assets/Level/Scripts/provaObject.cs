using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provaObject : MonoBehaviour
{
    public GameManager_V_Script gameManagerV;
    public bool collapsed;
    Animator animator;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerV = FindObjectOfType<GameManager_V_Script>();
        collapsed = false;
        animator = GetComponent<Animator>();
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
        gameManagerV.AddKey();
        Destroy(gameObject);
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