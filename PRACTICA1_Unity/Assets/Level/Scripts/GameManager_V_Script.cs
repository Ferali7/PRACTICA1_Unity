using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager_V_Script : MonoBehaviour
{
    //script que controla totes les variables que no es ressetegen al comen�ar cada nivell, sin� que es mantenen fins al final. vam trobar la dificultat que els men�s si no comen�aven de nou en cada nivell no es veien ben animats, llavors vam deixar al game manager inicial pels men�s i que es reinici�s a cada nivell, i vam crear un GameManager_Variables superior que tingu�s continuitat al llarg de tot el joc.
    public int numberKeys = 0;
    public int amountMoney = 0;
    public int amountMoneyLv1 = 0;
    public int amountMoneyLv2 = 0;
    public int amountMoneyLv3 = 0;
    //variable que utilitzarem per saber en quin nivell ens trobem i, en el cas de que ens hagi pillat la policia i volguem fer reset al nivell, quines monedes teniem al comen�ar aquell nivell i quin level hem de carregar
    public string currentLevel;
    public static GameManager_V_Script instance;
    //ho posem en awake, que passa abans del Start
    private void Awake()
    {
        //si el GameManager_Variables no ha ocorregut en cap instancia anterior, aquest script fa que la inst�ncia principal sigui aquesta, i si ja hi ha una inst�ncia, no assignar� una nova com a inst�ncia, sin� que destruir� la nova. aix� preveu duplicats de la inst�ncia
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
        //convertirem el valor de la variable string currentLevel en el nivell actual
        currentLevel = SceneManager.GetActiveScene().name;
        //funci� pels resets de diners, explicada m�s avall.
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
    //funci� que utilitzem, sobretot, per quan fem restart al morir en un nivell. A cada nivell que estem, a cada frame, es guarda el valor de diners actual en amountMoney(Lv actual). Al fer resset, carregarem els diners finals obtinguts en el nivell anterior, per comen�ar el nivell de nou sense els diners que hem aconseguit en el mateix abans de ser atrapats.
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