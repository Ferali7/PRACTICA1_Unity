using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager_MainMenu : MonoBehaviour
{
    //aquest és un gameManager que controla només elements que estan només presents al Main Menu. L'absència d'aquests elements a següents escenes donava algun error petit si colocavem aquests objectes al game manager principal i després aquests objectes no estaven a escenes posteriors. és per això que vam crear un manager dedicat només a aquests elements del Main Menu, que no apareix més endavant i no buscarà elements que no es troben als nivells.
    public GameObject SettingsMainMenu;
    // Start is called before the first frame update
    void Start()
    {
        //comença sent false el menú de settings
        SettingsMainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SettingsStartMenu()
    {
        //funció del botó per activar la visió del menu de settings
        SettingsMainMenu.SetActive(true);
    }
    public void BackToMainMenu()
    {
        //funció pel botó de tornar al main menu des del menu de settings inicial
        SettingsMainMenu.SetActive(false);
    }
}