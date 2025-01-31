using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Permanent : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI keysText;
    public int numberKeys = 0;
    public int amountMoney = 0;
    //Aquest script serveix �nicament per fer que la UI no es borri ni perdi dades al passar de nivell a nivell (o de pis en pis). Volem que el jugador segueixi tenint la mateixa quantitat de diners al passar d'un a altre i no s'inicialitzi.
    public static UI_Permanent instance;
    //aquesta funci� Awake, que passa abans que carregui el nivell i abans que void Start()
    private void Awake()
    {
        //si el UI no ha ocorregut en cap instancia, aquest script fa que la inst�ncia principal sigui aquesta, i si ja hi ha una inst�ncia, no assignar� una nova com a inst�ncia, sin� que destruir� la nova. aix� preveu duplicats de la inst�ncia.
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
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = amountMoney.ToString();
        keysText.text = numberKeys.ToString();
    }
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
    }
}
