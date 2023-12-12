using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaweController : MonoBehaviour
{
    public GameObject CharacterControllerGO;
    public int WaweLevel;
    public bool CanWawe = false;
    public float MaxExp;
    public Text WaveInfoo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WaveInfoo.text = "Wave /"+ WaweLevel;
        //Hangi Seviyede Olduðumuzu Söyler Ve Seviye geçiþleri arasýndaki koþulu kontrol eder
        if (WaweLevel == 0)
        {
            MaxExp = 50;
            WaweLevel = 1;
            
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 50 && WaweLevel == 1)
        {
            
            CanWawe = true;
            WaweLevel = 2;
            
            MaxExp = 150;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 150 && WaweLevel == 2)
        {
            
            CanWawe = true;
            WaweLevel = 3;
            
            MaxExp = 250;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 250 && WaweLevel == 3)
        {
            CanWawe = true;
            WaweLevel = 4;
            
            MaxExp = 350;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 350 && WaweLevel == 4)
        {
            CanWawe = true;
            WaweLevel = 5;
            
            MaxExp = 450;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 450 && WaweLevel == 5)
        {
            CanWawe = true;
            WaweLevel = 6;
            
            MaxExp = 550;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 550 && WaweLevel == 6)
        {
            CanWawe = true;
            WaweLevel = 7;
           
            MaxExp = 650;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 650 && WaweLevel == 7)
        {
            CanWawe = true;
            WaweLevel = 8;
            
            MaxExp = 750;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 750 && WaweLevel == 8)
        {
            CanWawe = true;
            WaweLevel = 9;
            
            MaxExp = 1000;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else if (CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp >= 1000 && WaweLevel == 9)
        {
            CanWawe = true;
            WaweLevel = 10;
            
            MaxExp = 1500;
            CharacterControllerGO.gameObject.GetComponent<CharacterControll>().Exp = 0;
        }
        else 
            CanWawe = false;
        
            
    }
    
}
