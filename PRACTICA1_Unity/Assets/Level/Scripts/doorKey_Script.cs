using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorKey_Script : MonoBehaviour
{
    public GameManager_V_Script gameManagerV;
    public bool collapsed;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerV = FindObjectOfType<GameManager_V_Script>();
        collapsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collapsed && Input.GetKeyDown(KeyCode.E) && gameManagerV.numberKeys > 0)
        {
            gameManagerV.numberKeys--;
            OnInteract();
        }
    }
    public void OnInteract()
    {
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