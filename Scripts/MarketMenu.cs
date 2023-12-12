using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketMenu : MonoBehaviour
{
    public GameObject MarketMenuu,Playerr;
    public Text BilgiText;
    // Start is called before the first frame update
    void Start()
    {
        MarketMenuu.SetActive(false);
    }
    public void MarketAc()
    {
        MarketMenuu.SetActive(true);
        Time.timeScale = 0f;
        BilgiText.text = "";
    }
    public void MarketKapat()
    {
        MarketMenuu.SetActive(false);
        Time.timeScale = 1f;
        BilgiText.text = "";
    }
    public void DamageArttýr()
    {
        Time.timeScale = 0f;
        if (Playerr.gameObject.GetComponent<CharacterControll>().TotalGold >= 100)
        {
            Playerr.gameObject.GetComponent<CharacterControll>().TotalGold = Playerr.gameObject.GetComponent<CharacterControll>().TotalGold - 100;
            Playerr.gameObject.GetComponent<CharacterControll>().DamagePlayer = Playerr.gameObject.GetComponent<CharacterControll>().DamagePlayer + 10f;
            BilgiText.color = Color.green;
            BilgiText.text = "Hasar + 10 Arttý";
        }
        else if (Playerr.gameObject.GetComponent<CharacterControll>().TotalGold < 100)
        {
            BilgiText.color = Color.red;
            BilgiText.text = "Yetersiz Altýn";
        }       
    }
    public void SpeeddArttýr()
    {
        Time.timeScale = 0f;
        if (Playerr.gameObject.GetComponent<CharacterControll>().TotalGold >= 100)
        {
            Playerr.gameObject.GetComponent<CharacterControll>().TotalGold = Playerr.gameObject.GetComponent<CharacterControll>().TotalGold - 100;
            Playerr.gameObject.GetComponent<CharacterControll>().hiz = Playerr.gameObject.GetComponent<CharacterControll>().hiz + 0.5f;
            BilgiText.color = Color.green;
            BilgiText.text = "Hýz + 10 Arttý";
        }
        else if (Playerr.gameObject.GetComponent<CharacterControll>().TotalGold < 100)
        {
            BilgiText.color = Color.red;
            BilgiText.text = "Yetersiz Altýn";      
        }
    }
    public void BenzinArttýr()
    {
        Time.timeScale = 0f;
        if(Playerr.gameObject.GetComponent<CharacterControll>().MaxBenzin >= Playerr.gameObject.GetComponent<CharacterControll>().Benzin + 20f && Playerr.gameObject.GetComponent<CharacterControll>().TotalGold >= 50)
        {
            Playerr.gameObject.GetComponent<CharacterControll>().TotalGold = Playerr.gameObject.GetComponent<CharacterControll>().TotalGold - 50;
            Playerr.gameObject.GetComponent<CharacterControll>().Benzin = Playerr.gameObject.GetComponent<CharacterControll>().Benzin + 20f;
            BilgiText.text = "Benzin + 20 Arttý";
            BilgiText.color = Color.green;
        }
        else if (Playerr.gameObject.GetComponent<CharacterControll>().TotalGold < 100)
        {
            BilgiText.color = Color.red;
            BilgiText.text = "Yetersiz Altýn";
        }
        else if (Playerr.gameObject.GetComponent<CharacterControll>().MaxBenzin < Playerr.gameObject.GetComponent<CharacterControll>().Benzin + 20f)
        {
            BilgiText.color = Color.red;
            BilgiText.text = "Benzin Zaten Dolu";  
        }
    }
}
