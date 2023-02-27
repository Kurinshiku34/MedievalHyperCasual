using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public static int level;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public GameObject purchaseErrorCoin;
    public GameObject purchaseErrorXp;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    void Start()
    {
        for(int i=0; i< shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        coins = PlayerPrefs.GetInt("Coins");
        //coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }
    void Update()
    {

    }
    public void AddCoins()                           
    {
        coins++;
        coinUI.text = coins.ToString();
        CheckPurchaseable();
    }
    public void CheckPurchaseable()                       //satin alinabilir mi?
    {
        for (int i=0; i<shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost)           //eger yeterli param varsa
                myPurchaseBtns[i].interactable = true;
        }

    }
    public void PurchaseItem(int BtnNo)                    //Buton numaralarina gore satin aliyor
    {
        if (coins >= shopItemsSO[BtnNo].baseCost)
        {
            coins = coins - shopItemsSO[BtnNo].baseCost;       //para - alinan seyin bedeli
            coinUI.text = coins.ToString();         //yeni para degerinin girilmesi
            CheckPurchaseable();
        }
        else
            purchaseErrorCoin.SetActive(true);            //para yetersiz hatasi verilmesi
    }
    public void LoadPanels()
    {
        for(int i= 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Price: " + shopItemsSO[i].baseCost.ToString();
            shopPanels[i].levelTxt.text = "Level: " + shopItemsSO[i].requiredLevel.ToString();
        }
    }
    public void ExitShop()
    {
        PlayerPrefs.SetInt("Coins", coins); 
    }
}
