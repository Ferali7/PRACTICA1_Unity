using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Permanent : MonoBehaviour
{
    public GameManager_V_Script gameManagerV;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI levelText;
    
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