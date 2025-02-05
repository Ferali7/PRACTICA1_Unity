using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematica_Script : MonoBehaviour
{
    //script que controla el temps que dura la cinemàtica (13.5segons)
    public float tempsCinematica = 13.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //anem restant el temps real de play a la variable. Quan valgui menys que 0, carreguem el main menu
        tempsCinematica -= Time.deltaTime;
        if (tempsCinematica < 0)
        {
            SceneManager.LoadScene("MAIN MENU");
        }
    }
}
