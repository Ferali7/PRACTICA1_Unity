using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager_Script : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject GameUI;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public GameObject CaughtMenu;
    public bool caught;
    // Start is called before the first frame update
    void Start()
    {
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
        if (caught)
        {
            Time.timeScale = 0f;
            CaughtMenu.SetActive(true);
        }
    }
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
    //funci� del men� Caught
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
    //funcions del men� principal
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