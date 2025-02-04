using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Permanent : MonoBehaviour
{
    public GameManager_V_Script gameManagerV;
    //public GameManager_Script gameManager;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI levelText;
    //Aquest script serveix �nicament per fer que la UI no es borri ni perdi dades al passar de nivell a nivell (o de pis en pis). Volem que el jugador segueixi tenint la mateixa quantitat de diners al passar d'un a altre i no s'inicialitzi.
    public static UI_Permanent instance;
    //aquesta funci� Awake, que passa abans que carregui el nivell i abans que void Start()
    private void Awake()
    {
        //si el UI no ha ocorregut en cap instancia, aquest script fa que la inst�ncia principal sigui aquesta, i si ja hi ha una inst�ncia, no assignar� una nova com a inst�ncia, sin� que destruir� la nova. aix� preveu duplicats de la inst�ncia.
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
        gameManagerV = FindObjectOfType<GameManager_V_Script>();
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = gameManagerV.amountMoney.ToString();
        keysText.text = gameManagerV.numberKeys.ToString();
        levelText.text = gameManagerV.currentLevel.ToString();
    }
}