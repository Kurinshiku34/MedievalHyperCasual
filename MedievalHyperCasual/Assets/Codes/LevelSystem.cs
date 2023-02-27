using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public int level;
    public float currentXp;
    public float requiredXp;

    public Button[] powerUpButtons;
    public GameObject powerUpButtonPanel;
    public GameObject powerUpButtonPanel2;
    private int XpGain;
    private int random;
    private int random2;
    private int speedCardCounter;

    private float lerpTimer;
    private float delayTimer;
    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;

    void Start()
    {
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        levelText.text = "level " + level;                     //level yazisi. (baslangicta 1 seviye olarak baslamasi icin)        

        XpGain = 10;
    }

    void Update()
    {
        updateXpUI();
        if (Input.GetKeyDown(KeyCode.E))            //ONEMLI!!! //musteri yiyip icip kalktiginda exp gelecek, bunun kodlanacagi yer burasi. update fonksiyonu icinden alinip musteri kalktiginda fonksiyonuna yerlestirilecek.
            gainExperienceFlatRate(XpGain);             //"10" gelen exp sayisi (degisken)
        if (Input.GetKeyDown(KeyCode.F))            //ONEMLI!!! //musteri sinirlenip kalktiginda exp kaybedecek, bunun kodlanacagi yer burasi. update fonksiyonu icinden alinip musteri kalktiginda fonksiyonuna yerlestirilecek.
            loseExperienceFlatRate(10);             //"10" giden exp sayisi (degisken)
        if (currentXp >= requiredXp)                //eger (suanki xp, seviye atlamak icin gereken xp'den fazla ya da esit ise (degistirilebilir) seviye atla)
            levelUp();
    }

    public void updateXpUI()                        //gelen xp'nin xp barina islemesi
    {
        float xpFraction = currentXp / requiredXp;
        float FXP = frontXpBar.fillAmount;
        if (FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if (delayTimer > 0.5)                                                //xp barinin ilerleme suresi buradan ayarlanacak
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 1;                          //xp barinin ilerleme suresi buradan ayarlanacak
                frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }
        if (FXP > xpFraction)                      //giden xp'nin xp barina islemesi
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if (delayTimer > 0.5)                                                //xp barinin ilerleme suresi buradan ayarlanacak
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 1;                           //xp barinin ilerleme suresi buradan ayarlanacak
                frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }
        xpText.text = currentXp + "/" + requiredXp;
    }

    public void gainExperienceFlatRate(float xpGained)      //xp kazanci
    {
        currentXp += xpGained;
        lerpTimer = 0f;
        delayTimer = 0f;
    }
    public void loseExperienceFlatRate(float xpLosed)      //xp kaybi
    {
        if (currentXp > 0)
        {
            currentXp -= xpLosed;
            lerpTimer = 0f;
            delayTimer = 0f;
        }
    }

    public void levelUp()     //seviye atladiginda kazanacagi ozellikler burada kodlanacak
    {
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = 0f;
        requiredXp = requiredXp + 50;
        levelText.text = "level " + level;          //level yazisi (Her seviye arttiginda yenilenir)       

        powerUpButtonPanel.SetActive(true);
        powerUpButtonPanel2.SetActive(true);

        random = Random.Range(0, 3);
        random2 = Random.Range(3, 6);

        if (random == 0 && speedCardCounter < 5)
        {
            powerUpButtons[random].gameObject.SetActive(true);
        }
        else
        {
            random = Random.Range(1, 3);
            powerUpButtons[random].gameObject.SetActive(true);
        }
        powerUpButtons[random2].gameObject.SetActive(true);

    }
    public void playerSpeed()
    {
        //FindObjectOfType<Player>().speed += 5f;                          //deðeri deðiþtirebilirsiniz kafama göre koydum
        speedCardCounter += 1;
        powerUpButtonPanel.SetActive(false);
        powerUpButtonPanel2.SetActive(false);
        powerUpButtons[random].gameObject.SetActive(false);
        powerUpButtons[random2].gameObject.SetActive(false);
    }

    public void xpGain()
    {
        XpGain += 5;
        powerUpButtonPanel.SetActive(false);
        powerUpButtonPanel2.SetActive(false);
        powerUpButtons[random].gameObject.SetActive(false);
        powerUpButtons[random2].gameObject.SetActive(false);
    }

    public void moneyGain()
    {

        powerUpButtonPanel.SetActive(false);
        powerUpButtonPanel2.SetActive(false);
        powerUpButtons[random].gameObject.SetActive(false);
        powerUpButtons[random2].gameObject.SetActive(false);
    }

    public void customerCapacity()
    {

        powerUpButtonPanel.SetActive(false);
        powerUpButtonPanel2.SetActive(false);
        powerUpButtons[random].gameObject.SetActive(false);
        powerUpButtons[random2].gameObject.SetActive(false);
    }
    public void itemCapacity()
    {

        powerUpButtonPanel.SetActive(false);
        powerUpButtonPanel2.SetActive(false);
        powerUpButtons[random].gameObject.SetActive(false);
        powerUpButtons[random2].gameObject.SetActive(false);
    }

    public void workerCapacity()
    {

        powerUpButtonPanel.SetActive(false);
        powerUpButtonPanel2.SetActive(false);
        powerUpButtons[random].gameObject.SetActive(false);
        powerUpButtons[random2].gameObject.SetActive(false);
    }
}