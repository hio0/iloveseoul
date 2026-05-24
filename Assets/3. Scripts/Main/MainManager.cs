using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager main;

    public Division[] divisons;

    public float allhogamdo;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Division div in divisons)
        {
            allhogamdo += div.hogamdo;
        }

        MoneyManager.Money.SetHogamdo(allhogamdo);
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

        MoneyManager.Money.SetHogamdo(allhogamdo);
    }
}
