using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class provaLetrero : MonoBehaviour
{
    public bool collapsed;
    public string boardText = "Tonto el que haya pulsado E";
    public GameObject boardUI;
    public Text boardTextUI;
    // Start is called before the first frame update
    void Start()
    {
        collapsed = false;
        boardUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (collapsed && Input.GetKeyDown(KeyCode.E))
        {
            ShowBoard(true);
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
    public void ShowBoard(bool show)
    {
        if (show == true)
        {

            boardTextUI.text = boardText;
            boardUI.SetActive(true);
        }
        else
        {
            boardUI.SetActive(false);
        }
    }
}
