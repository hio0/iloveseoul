using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hogamdo : MonoBehaviour
{
    public Division division;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoneySet()
    {
        MoneyManager.Money.moneyRise += division.hogamdo;
    }
}
