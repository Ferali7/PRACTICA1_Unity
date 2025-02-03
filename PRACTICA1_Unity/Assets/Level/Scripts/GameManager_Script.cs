using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Script : MonoBehaviour
{
    public int numberKeys = 0;
    public int amountMoney = 0;
    public bool isPaused = false;
    public GameObject PauseMenu;
    public static GameManager_Script instance;
    private void Awake()
    {
        //si el GameManager no ha ocorregut en cap instancia anterior, aquest script fa que la instància principal sigui aquesta, i si ja hi ha una instància, no assignarà una nova com a instància, sinó que destruirà la nova. això preveu duplicats de la instància.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    //funcions per controlar les variables
    public void AddKey()
    {
        numberKeys++;
    }
    public void UseKey()
    {
        numberKeys--;
    }
    public void AddMoney()
    {
        int randomMoney = Random.Range(300, 500);
        amountMoney = amountMoney + randomMoney;
    }
    //funcions del menú de pausa
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
