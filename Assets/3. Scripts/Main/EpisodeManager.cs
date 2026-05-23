using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EpisodeManager : MonoBehaviour
{
    Division targetdivision;
    Episode episode;

    int talktime;
    bool talkingyet;
    int oneselecttime;
    int selecttime;
    bool isnormaltalk;
    string log;

    [SerializeField] GameObject talkP;
    [SerializeField] Image charimage;
    [SerializeField] TMP_Text nameT;
    [SerializeField] TMP_Text mainT;

    [SerializeField] Transform selects;
    [SerializeField] GameObject select;

    // Start is called before the first frame update
    void Start()
    {
        talkP.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (talkP.activeSelf && !talkingyet)
            {
                SetNextTalk();
            }
        }
    }

    public void StartTalk(Division div)
    {
        targetdivision = div;
        episode = targetdivision.episodes[targetdivision.episodeCount];
       
        talktime = 0;
        selecttime = 0;
        isnormaltalk = true;
        charimage.sprite = targetdivision.me.charactor;

        talkP.SetActive(true); 
        SetNextTalk();

        talkP.GetComponent<RectTransform>().localPosition = new Vector3(2000, 0, 0);
        StartCoroutine(MoveAnimation(talkP, new Vector3(0, 0, 0),1.5f));
    }

    IEnumerator MoveAnimation(GameObject what, Vector3 target, float speed)
    {
        while(what.transform.position != target)
        {
            what.transform.position = Vector3.MoveTowards(what.transform.position, target, speed);
            yield return null;
        }
    }

    void SetNextTalk()
    {
        if (talktime >= episode.texts.Length)
        {
            EndTalk();
        }
        else
        {
            talkingyet = true;
            Action action = null;

            if (isnormaltalk)
            {
                log = episode.texts[talktime];

                if (log.Contains("*"))
                {
                    action = SetSelect;

                    log = log.Replace("*", "");
                }
                else
                {
                    action = OneTalkEnd;
                }

                Talking(log, action);
            }
            else
            {
                action = null;
                Talking(log, action);
            }
        }
    }

    void SetSelect()
    {
        List<Select> nowselect = new List<Select>();

        for (int i = 0; i < episode.selects.Length; i++)
        {
            if (episode.selects[i].th == selecttime)
            {
                nowselect.Add(episode.selects[i]);
            }
        }

        for (int i = 0; i < nowselect.Count; i++)
        {
            GameObject pre = Instantiate(select, selects);

            pre.transform.SetSiblingIndex(0);
            pre.GetComponent<SelectButton>().myselect = nowselect[i];
            pre.transform.GetComponentInChildren<TMP_Text>().text = nowselect[i].selectname;
            pre.GetComponent<Button>().onClick.AddListener(() => SetSelectTalk(gameObject));
        }

        isnormaltalk = false;
        selecttime++;
        oneselecttime = 0;
    }

    void SetSelectTalk(GameObject you)
    {
        Debug.Log(you.name, you.GetComponent<SelectButton>().myselect);
        Select sb = you.GetComponent<SelectButton>().myselect;

        if (oneselecttime >= sb.selectedlog.Length)
        {
            OneTalkEnd();
        }
        else
        {
            if(oneselecttime == 0)
            {
                if(sb.iscorrect)
                {
                    Correct();
                }
                else
                {
                    Miss();
                }
            }

            log = sb.selectedlog[oneselecttime];
            oneselecttime++;
        }
    }

    void OneTalkEnd()
    {
        talkingyet = false;
        isnormaltalk = true;
        talktime++;
    }

    void Talking(string log, Action action)
    {
        bool isme = false;

        if (log.Contains("#"))
        {
            isme = true;
            log = log.Replace("#", "");
        }

        if (isme)
        {
            charimage.color = new Color(146, 146, 146);
            nameT.text = "나";
        }
        else
        {
            charimage.color = new Color(0, 0, 0);
            nameT.text = targetdivision.me.name;
        }

        StartCoroutine(TypeText(log, action));
    }

    public IEnumerator TypeText(string text, Action action)
    {
        mainT.text = ""; // 텍스트 초기화

        foreach (char letter in text.ToCharArray())
        {
            mainT.text += letter; // 한 글자씩 추가
            yield return new WaitForSeconds(0.05f); // 글자 사이에 딜레이
        }

        action?.Invoke();
    }

    void Correct()
    {
        targetdivision.hogamdo += targetdivision.hogamdo / 2;
        MoneyManager.Money.moneyRise += targetdivision.hogamdo;
    }

    void Miss()
    {
        targetdivision.hogamdo -= targetdivision.hogamdo / 5;
        MoneyManager.Money.moneyRise += targetdivision.hogamdo;
    }

    void EpisodeHappyEnd()
    {
        targetdivision.hogamdo *= 3;
        MoneyManager.Money.moneyRise += targetdivision.hogamdo;

        targetdivision.episodeCount++;
    }

    public void EndTalk()
    {
        talkP.SetActive(false);
    }
}
