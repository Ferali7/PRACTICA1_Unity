using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager_V_Script : MonoBehaviour
{
    public int numberKeys = 0;
    public int amountMoney = 0;
    public int amountMoneyLv1 = 0;
    public int amountMoneyLv2 = 0;
    public int amountMoneyLv3 = 0;
    public string currentLevel;
    public static GameManager_V_Script instance;
    private void Awake()
    {
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
    //funcions per controlar les variables
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