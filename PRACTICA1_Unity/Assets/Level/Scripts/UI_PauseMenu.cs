using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_PauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    Animator animator;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        print("ENTRAS???");
        Time.timeScale = 1.0f;
        animator = GetComponent<Animator>();
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("ESCAOPEEEEE");
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
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        //Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MAIN MENU");
    }
    public void Settings()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SETTINGS");
    }
}
