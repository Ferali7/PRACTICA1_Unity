using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager_MainMenu : MonoBehaviour
{
    public GameObject SettingsMainMenu;
    // Start is called before the first frame update
    void Start()
    {
        SettingsMainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SettingsStartMenu()
    {
        SettingsMainMenu.SetActive(true);
    }
    public void BackToMainMenu()
    {
        SettingsMainMenu.SetActive(false);
    }
}