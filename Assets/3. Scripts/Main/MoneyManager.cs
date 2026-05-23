using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Money;

    public float money = 0;
    public float moneyRise = 1;
    [SerializeField] float moneytimer;

    private void Awake()
    {
        if (Money == null)
        {
            Money = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneytimer += Time.deltaTime;
        if(moneytimer >= 1f)
        {
            PlusMoney();
            moneytimer = 0f;
        }
    }

    void PlusMoney()
    {
        money += moneyRise;
    }
}
