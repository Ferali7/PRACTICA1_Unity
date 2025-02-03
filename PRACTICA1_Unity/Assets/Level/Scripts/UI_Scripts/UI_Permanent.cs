using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Permanent : MonoBehaviour
{
    public GameManager_Script gameManager;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI keysText;
    //Aquest script serveix únicament per fer que la UI no es borri ni perdi dades al passar de nivell a nivell (o de pis en pis). Volem que el jugador segueixi tenint la mateixa quantitat de diners al passar d'un a altre i no s'inicialitzi.
    public static UI_Permanent instance;
    //aquesta funció Awake, que passa abans que carregui el nivell i abans que void Start()
    private void Awake()
    {
        //si el UI no ha ocorregut en cap instancia, aquest script fa que la instància principal sigui aquesta, i si ja hi ha una instància, no assignarà una nova com a instància, sinó que destruirà la nova. això preveu duplicats de la instància.
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
        gameManager = FindObjectOfType<GameManager_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = gameManager.amountMoney.ToString();
        keysText.text = gameManager.numberKeys.ToString();
    }
}