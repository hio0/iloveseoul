using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public Division[] divisons;

    public float allhogamdo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void GetAllHogamdo()
    {
        allhogamdo = 0;

        foreach(Division div  in divisons)
        {
            allhogamdo += div.hogamdo;
        }

        MoneyManager.Money.hogamdo = allhogamdo;
    }
}
