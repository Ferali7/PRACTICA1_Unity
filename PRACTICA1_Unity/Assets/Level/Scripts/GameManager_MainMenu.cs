using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager_MainMenu : MonoBehaviour
{
    //aquest �s un gameManager que controla nom�s elements que estan nom�s presents al Main Menu. L'abs�ncia d'aquests elements a seg�ents escenes donava algun error petit si colocavem aquests objectes al game manager principal i despr�s aquests objectes no estaven a escenes posteriors. �s per aix� que vam crear un manager dedicat nom�s a aquests elements del Main Menu, que no apareix m�s endavant i no buscar� elements que no es troben als nivells.
    public GameObject SettingsMainMenu;
    // Start is called before the first frame update
    void Start()
    {
        //comen�a sent false el men� de settings
        SettingsMainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SettingsStartMenu()
    {
        //funci� del bot� per activar la visi� del menu de settings
        SettingsMainMenu.SetActive(true);
    }
    public void BackToMainMenu()
    {
        //funci� pel bot� de tornar al main menu des del menu de settings inicial
        SettingsMainMenu.SetActive(false);
    }
}