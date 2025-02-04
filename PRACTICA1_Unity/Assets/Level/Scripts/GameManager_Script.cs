using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager_Script : MonoBehaviour
{
    public GameManager_V_Script gameManagerV;
    public bool isPaused = false;
    public GameObject GameUI;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public GameObject CaughtMenu;
    public bool caught;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerV = GameObject.FindObjectOfType<GameManager_V_Script>();
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        CaughtMenu.SetActive(false);
        caught = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MAIN MENU" || SceneManager.GetActiveScene().name == "END_Victory")
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
            if (Input.GetKeyDown(KeyCode.B))
            {
                Restart();
                
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
            if (caught)
            {
                Time.timeScale = 0f;
                isPaused = true;
                CaughtMenu.SetActive(true);
            }
        }

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
        gameManagerV.numberKeys = 0;
        gameManagerV.amountMoney = 0;
        gameManagerV.amountMoneyLv1 = 0;
        gameManagerV.amountMoneyLv2 = 0;
        gameManagerV.amountMoneyLv3 = 0;
        SceneManager.LoadScene("MAIN MENU");
    }
    //funció del menú Caught
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (gameManagerV.currentLevel == "LEVEL 1")
        {
            gameManagerV.amountMoney = 0;
        }
        if (gameManagerV.currentLevel == "LEVEL 2")
        {
            gameManagerV.amountMoney = gameManagerV.amountMoneyLv1;
        }
        if (gameManagerV.currentLevel == "LEVEL 3")
        {
            gameManagerV.amountMoney = gameManagerV.amountMoneyLv2;
        }
    }    
    //funcions del menú principal
    public void PlayGame()
    {
        SceneManager.LoadScene("LEVEL 1");
    }
    /*public void SettingsStartMenu()
    {
        SettingsMainMenu.SetActive(true);
    }
    public void BackToMainMenu()
    {
        SettingsMainMenu.SetActive(false);
    }*/
    public void WebsiteButton()
    {
        print("GO TO WEBSITEEE");
    }
    public void Exit()
    {
        Application.Quit();
    }
}