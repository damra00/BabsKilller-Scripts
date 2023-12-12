using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject ExpObject ,DefaultEnemy,Enemy1,Enemy2,Enemy3,Enemy4, Enemy5, Enemy6, Enemy7, Enemy8, Enemy9,Enemy10,WaweControllE_S;
    public int xPos,zPos,EnemyCount,ExpCount;
    int NextWawe;
    bool CanWaweE_S;
  
   

    // Start is called before the first frame update
    void Start()
    {
        //Baþlangýçta hangi Özellikte Hangi Düþman Spawn Olacak
        DefaultEnemy = Enemy1;
        EnemyCount = 10;
        StartCoroutine(MobSpawner());
        StartCoroutine(ExpSpawner());


    }

    // Update is called once per frame
    void Update()
    {

        //WaweController scriptinden veri çek
        CanWaweE_S = WaweControllE_S.gameObject.GetComponent<WaweController>().CanWawe;
        NextWawe = WaweControllE_S.gameObject.GetComponent<WaweController>().WaweLevel;

        //Hangi Seviyede Hangi Özellikte, Hangi Düþman Spawn Olacak
        if (NextWawe ==2 && CanWaweE_S == true)
        {
            DefaultEnemy = Enemy2;
            EnemyCount = 15;
            StartCoroutine(MobSpawner());
        }
        else if (NextWawe == 3 && CanWaweE_S == true)
        {
            DefaultEnemy = Enemy3;
            EnemyCount = 20;
            StartCoroutine(MobSpawner());
        }
        else if (NextWawe == 4 && CanWaweE_S == true)
        {
            DefaultEnemy = Enemy4;
            EnemyCount = 25;
            StartCoroutine(MobSpawner());
        }
        else if (NextWawe == 5 && CanWaweE_S == true)
        {
            DefaultEnemy = Enemy5;
            EnemyCount = 30;
            StartCoroutine(MobSpawner());
        }
        else if (NextWawe == 6 && CanWaweE_S == true)
        {
            
            DefaultEnemy = Enemy6;
            EnemyCount = 35;
            StartCoroutine(MobSpawner());
        }
        else if (NextWawe == 7 && CanWaweE_S == true)
        {
            DefaultEnemy = Enemy7;
            EnemyCount = 40;
            StartCoroutine(MobSpawner());
        }
        else if (NextWawe == 8 && CanWaweE_S == true)
        {
            DefaultEnemy = Enemy8;
            EnemyCount = 40;
            StartCoroutine(MobSpawner());
        }
        else if (NextWawe == 9 && CanWaweE_S == true)
        {
            
            DefaultEnemy = Enemy9;
            EnemyCount = 45;
            StartCoroutine(MobSpawner());
        }
        else if (NextWawe == 10 && CanWaweE_S == true)
        {
            DefaultEnemy = Enemy10;
            EnemyCount = 1;
            StartCoroutine(MobSpawner());
            DefaultEnemy = Enemy9;
            EnemyCount = 20;
            StartCoroutine(MobSpawner());
            
        }
    }
    IEnumerator MobSpawner()
    {
        //Spawner
        while(EnemyCount > 0 )
        {
            xPos = Random.Range(-2, 3);
            zPos = Random.Range(-3, 3);
            Instantiate(DefaultEnemy, new Vector3(xPos, -1f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            EnemyCount -= 1;
        }
    }
    IEnumerator ExpSpawner()
    {
        //Spawner
        while (ExpCount > 0)
        {
            xPos = Random.Range(-4, 4);
            zPos = Random.Range(-4, 4);
            Instantiate(ExpObject, new Vector3(xPos, 0.1f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            ExpCount -= 1;
        }
        
    }
}
