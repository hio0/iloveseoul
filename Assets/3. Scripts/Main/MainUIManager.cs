using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    public TMP_Text moneyT;
    public TMP_Text moneyraiseT;
    public TMP_Text hogamdoT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextChange();
    }

    public void TextChange()
    {
        moneyT.text = $"돈 : <b>{MoneyManager.Money.money.ToString("F1")}</b>";
        moneyraiseT.text = MoneyManager.Money.moneyRise.ToString("F1") + "/s";
    }
}
