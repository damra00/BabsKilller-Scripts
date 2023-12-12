using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpScript : MonoBehaviour
{
    float sayac;
    // Start is called before the first frame update
    void Start()
    {
        sayac = 30;

    }

    // Update is called once per frame
    void Update()
    {
        sayac -= Time.deltaTime;
        if(sayac <= 0)
        {
            Destroy(gameObject);
        }
    }
}
