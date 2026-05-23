using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Money;

    public float money;
    public float hogamdo;
    [SerializeField] float moneytimer;

    public TMP_Text moneyT;
    public TMP_Text hogamdoT;

    private void Awake()
    {
        if (Money == null)
        {
            Money = this;
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
        if (moneytimer >= 1f)
        {
            PlusMoney();
            moneytimer = 0f;
        }
    }

    void PlusMoney()
    {
        money += hogamdo;
        moneyT.text = $"돈 : <b>{money.ToString("F1")}</b>";
    }

    public IEnumerator HogamdoToMoney(float much)
    {
        hogamdoT.text = $"호감도가 조금 오른 것 같다...! <b>({hogamdo.ToString("F1")}/s -> {much.ToString("F1")}/s)</b>";
        yield return new WaitForSeconds(3f);

        hogamdo = much;
        hogamdoT.text = $"호감도: <b>{hogamdo.ToString("F1")}/s</b>";
    }
}
