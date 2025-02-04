using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager_V_Script : MonoBehaviour
{
    //script que controla totes les variables que no es ressetegen al comen�ar cada nivell, sin� que es mantenen fins al final
    public int numberKeys = 0;
    public int amountMoney = 0;
    public int amountMoneyLv1 = 0;
    public int amountMoneyLv2 = 0;
    public int amountMoneyLv3 = 0;
    public string currentLevel;
    public static GameManager_V_Script instance;
    //ho posem en awake, que passa abans del Start
    private void Awake()
    {
        ////si el GameManager_Variables no ha ocorregut en cap instancia, aquest script fa que la inst�ncia principal sigui aquesta, i si ja hi ha una inst�ncia, no assignar� una nova com a inst�ncia, sin� que destruir� la nova. aix� preveu duplicats de la inst�ncia
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
        currentLevel = SceneManager.GetActiveScene().name;
        UpdateMoney();
    }
    //funcions per controlar el augment de variables
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
    //funci� que utilitzem, sobretot, per quan fem restart al morir en un nivell. A cada nivell que estem, es guarda el valor de diners actual en amountMoney(Lv actual). Al fer resset, carregarem els diners finals obtinguts en el nivell anterior, per comen�ar el nivell de nou sense els diners que hem aconseguit en el mateix abans de morir.
    public void UpdateMoney()
    {
        if (currentLevel == "LEVEL 1")
        {
            amountMoneyLv1 = amountMoney;
        }
        if (currentLevel == "LEVEL 2")
        {
            amountMoneyLv2 = amountMoney;
        }
        if (currentLevel == "LEVEL 3")
        {
            amountMoneyLv3 = amountMoney;
        }
    }
}