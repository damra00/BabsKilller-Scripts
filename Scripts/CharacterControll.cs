using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControll : MonoBehaviour
{
    public AudioSource src,src2;
    public AudioClip Vurunca, Bosta;
    public Button MarketButtons,RestartBtn,QuitBtn;
    public FixedJoystick Joystick;
    public Text GoldText,OyunInfoText;
    public Image BenzinBar,ExpBar;
    GameObject other;
    public GameObject Dusman,WaweControllerCC;
    public TrailRenderer tr;
    public Rigidbody rg;
    public float hiz , Benzin,MaxBenzin,Exp;
    float dikey;
    float yatay;
    public int TotalGold;
    public float MaxExpp;
    public bool OyunDevam;
    public float DamagePlayer;
    bool Kazandýn,BossaVuruyor;
    float BenzinEksilmeHizi;
    // Start is called before the first frame update
    void Start()
    {
        src.clip = Bosta;
        src.Play();
        Benzin = 50f; 
    }
    // Update is called once per frame
    void Update()
    {  
        MaxExpp = WaweControllerCC.gameObject.GetComponent<WaweController>().MaxExp;
        GoldText.text = TotalGold + "";
        Benzin -= Time.deltaTime*BenzinEksilmeHizi;
        BenzinBar.fillAmount = Benzin / MaxBenzin;
        ExpBar.fillAmount = (float)(Exp / MaxExpp);
        if (BossaVuruyor == true)
        {
            BenzinEksilmeHizi = 2;
        }
        else
        {
            BenzinEksilmeHizi = 1;
        }
        if(Benzin > 0 && Kazandýn == false)
        {
            OyunDevam = true;
            OyunInfoText.text = "";
            RestartBtn.gameObject.SetActive(false);
            QuitBtn.gameObject.SetActive(false);
        }
        else if(Benzin <= 0)
        {
            OyunDevam = false;
            OyunInfoText.color = Color.red;
            OyunInfoText.text = "Benzin Bitti";
            RestartBtn.gameObject.SetActive(true);
            QuitBtn.gameObject.SetActive(true);
        }
        else if (Kazandýn== true)
        {
            OyunDevam = false;
            OyunInfoText.color = Color.green;
            OyunInfoText.text = "Kazandýn";
            RestartBtn.gameObject.SetActive(true);
            QuitBtn.gameObject.SetActive(true);
        }
        else
        {
            RestartBtn.gameObject.SetActive(false);
            QuitBtn.gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
    {    
        if (OyunDevam)
        {
            // Karakter Hareket
            dikey = Input.GetAxis("Vertical");
            yatay = Input.GetAxis("Horizontal");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            //Vector3 kuvvetJoystick = new Vector3(-Joystick.Vertical, 0, Joystick.Horizontal);
            rg.velocity = (kuvvet * hiz);
            //rg.velocity = (kuvvetJoystick * hiz);
        }
    }
   
     void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Kupa"))
        {
            other = collision.gameObject;
            Destroy(other);
            Kazandýn = true;
        }
        //Toplanan Gold
        if ((collision.gameObject.tag == "Gold"))
        {
            other = collision.gameObject;
            Destroy(other);
            TotalGold = TotalGold + 5;
        }
        //Toplanan Benzin
        if ((collision.gameObject.tag == "Benzin") && MaxBenzin >= Benzin + 10f)
        {
            other = collision.gameObject;
            Destroy(other);
            Benzin = Benzin + 10f;
            TotalGold = TotalGold + 5;        
        }
        //Toplanan Exp
        if ((collision.gameObject.tag == "Exp"))
        {
            other = collision.gameObject;
            Destroy(other);
            Exp = Exp + 5;
        }
        //Dusmana verilen hasar
        if ((collision.gameObject.tag == "Enemy"))
        {
            Dusman = collision.gameObject;
            Dusman.gameObject.GetComponent<EnemyAI>().Damage = DamagePlayer ;
            src2.clip = Vurunca;
            src2.Play();
        }
        
        //Boss Hasar 
        if ((collision.gameObject.tag == "Boss"))
        {         
            Dusman = collision.gameObject;
            Dusman.gameObject.GetComponent<BossCS>().Damage = DamagePlayer;
            BossaVuruyor = true;
            src2.clip = Vurunca;
            src2.Play();
        }
        else
        {
            BossaVuruyor = false;        
        }
    }
    private void OnCollisionStay(Collision collision)
    {      
        if ((collision.gameObject.tag == "Market"))
        {
            MarketButtons.gameObject.SetActive(true);
        }
        else
        {
            MarketButtons.gameObject.SetActive(false);
        }      
    }
}
