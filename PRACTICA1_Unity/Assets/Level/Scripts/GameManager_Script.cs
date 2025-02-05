using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager_Script : MonoBehaviour
{
    //gameManager que inicialment es va pensar que existís de forma continua al joc, però al trobar problemes en les animacions del menú per no fer-se resset a cada escena, vam decidir dedicarlo a coses només visuals de l'UI, faria resset a cada escena, i utilitzarem el GameManager_Variables per guardar valors d'escena en escena
    public GameManager_V_Script gameManagerV;
    //booleana que ens indica si esta en pausa el joc o no, permetent coses com el pas del temps o el sprite canviant del jugador
    public bool isPaused = false;
    public GameObject GameUI;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public GameObject CaughtMenu;
    //booleana que si està en true, activarà la interficie de capturat i només els botons de resset o main menu
    public bool caught;
    // Start is called before the first frame update
    void Start()
    {
        //trobem el gamemanagerVariables a l'escena
        gameManagerV = GameObject.FindObjectOfType<GameManager_V_Script>();
        //assegurem que l'escena comença amb timescale 1, no fos cas que ha colapsat la pausa d'un nivell anterior simultànea amb canviar de nivell
        Time.timeScale = 1.0f;
        //inicialitzem els menús de la UI com a falsos, perquè no es mostrin en pantalla, només quan els activem
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        CaughtMenu.SetActive(false);
        caught = false;
    }

    // Update is called once per frame
    void Update()
    {
        //si l'escena en la que estem és el main menu o la pantalla de victòria, la UI no estarà activa. Alhora, tampoc podrem pulsar tecles com "Next level" o "Restart" o la tecla Escape i fer Pausa ja que estan en l'ELSE.
        if (SceneManager.GetActiveScene().name == "MAIN MENU" || SceneManager.GetActiveScene().name == "END_Victory")
        {
            GameUI.SetActive(false);
        }
        else
        {
            //si pulses N, garantitzes que el timescale sigui 1 i passes al seguent nivell. si pulses B, resseteges el nivell.
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
            //al estar en una escena que no sigui Main menu o Victory, pots veure la UI del joc (variables, menu pausa, settings...)
            GameUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //si isPaused es vertader, la tecla Escape fa que continuem la partida, i si fos falsa, la pausem
                if (isPaused == true)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
            //si la variable caught es verdadera, parem el temps, parem al jugador i mostrem la pantalla de PILLAT
            if (caught)
            {
                Time.timeScale = 0f;
                isPaused = true;
                CaughtMenu.SetActive(true);
            }
        }

    }
    //funcions del menú de pausa, principalment funcions per als botons
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
        //si tornem al main menu, totes les variables hauran de baixar a 0 per tornar a començar
        gameManagerV.numberKeys = 0;
        gameManagerV.amountMoney = 0;
        gameManagerV.amountMoneyLv1 = 0;
        gameManagerV.amountMoneyLv2 = 0;
        gameManagerV.amountMoneyLv3 = 0;
    }
    //funció del menú Caught
    public void Restart()
    {
        Time.timeScale = 1f;
        gameManagerV.numberKeys = 0;
        //coneixem quina es l'escena actual mitjançant current level del script GameManager_V_Script. Si correspon a LEVEL 1, al fer resset posarem les variables a 0. Si erem al level 2, agafarem els diners que teniem al completar el lvl1 per reiniciarlo, i conseqüentment
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
        SceneManager.LoadScene(gameManagerV.currentLevel);
    }    
    //funcions del menú principal
    public void PlayGame()
    {
        SceneManager.LoadScene("LEVEL 1");
    }
    //Al desactivar la Game UI en el menu principal, i la Game UI contenia el menu de settings, vam fer un de nou només pel main menu, i aquest era controlat pel GameManager_MainMenu_Script específic del Main Menu
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
        Application.OpenURL("https://garciaarcampusemav.wixsite.com/quirky-sprite-studio");
    }
    public void Exit()
    {
        Application.Quit();
    }
}