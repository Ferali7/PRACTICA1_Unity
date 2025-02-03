using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorKey_Script : MonoBehaviour
{
    public UI_Permanent UI_Permanent;
    public bool collapsed;
    // Start is called before the first frame update
    void Start()
    {
        collapsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collapsed && Input.GetKeyDown(KeyCode.E) && UI_Permanent.numberKeys > 0)
        {
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