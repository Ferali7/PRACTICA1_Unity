using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager_Script : MonoBehaviour
{
    /*public int numberKeys = 0;
    public int amountMoney = 0;
    public int amountMoneyLv1 = 0;
    public int amountMoneyLv2 = 0;
    public int amountMoneyLv3 = 0;*/
    public bool isPaused = false;
    public GameObject GameUI;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public static GameManager_Script instance;
    private void Awake()
    {
        //si el GameManager no ha ocorregut en cap instancia anterior, aquest script fa que la inst�ncia principal sigui aquesta, i si ja hi ha una inst�ncia, no assignar� una nova com a inst�ncia, sin� que destruir� la nova. aix� preveu duplicats de la inst�ncia.
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MAIN MENU" || SceneManager.GetActiveScene().name == "SETTINGS")
        {
            GameUI.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                Time.timeScale = 1f;
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            GameUI.SetActive(true);
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

    }
    /*//funcions per controlar les variables
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
    }*/
    //funcions del men� de pausa
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
    public void PauseSettings()
    {
        SettingsMenu.SetActive(true);
    }
    public void BackSettings()
    {
        SettingsMenu.SetActive(false);
    }
    public void MainMenu()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MAIN MENU");
    }
    //funcions del men� principal
    public static void PlayGame()
    {
        SceneManager.LoadScene("LEVEL 1");
    }
    public static void SettingsStartMenu()
    {
        SceneManager.LoadScene("SETTINGS");
    }
    public static void BackToMainMenu()
    {
        SceneManager.LoadScene("MAIN MENU");
    }
    public static void WebsiteButton()
    {
        print("GO TO WEBSITEEE");
    }
    public static void Exit()
    {
        Application.Quit();
    }
}