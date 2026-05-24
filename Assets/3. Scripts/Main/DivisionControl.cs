using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DivisionControl : MonoBehaviour
{
    public Division my;
    public Event myevent;
    public Vector2 uipos;

    public GameObject eventalim;
    [SerializeField]float eventimer;
    [SerializeField] float eventzuttotimer;
    [SerializeField]bool timersetting;
    bool zuttotimersetting;

    public TMP_Text hogamdoT;

    // Start is called before the first frame update
    void Start()
    {
        eventalim.SetActive(false);
        timersetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!EpisodeManager.Episode.talking)
        {
            if (!timersetting)
            {
                eventimer = Random.Range(MainManager.main.divisons.Length * 2, MainManager.main.divisons.Length * 12);
                timersetting = true;
            }
            else
            {
                eventimer -= Time.deltaTime;

                if (eventimer < 0)
                {
                    eventimer = 0;
                    EventManager.Event.SetNewEvent(gameObject.GetComponent<RectTransform>());
                    eventalim.SetActive(true);
                }
            }

            if (eventalim.activeSelf)
            {
                if (!zuttotimersetting)
                {
                    eventzuttotimer = Random.Range(MainManager.main.divisons.Length * 5, MainManager.main.divisons.Length * 12);
                    zuttotimersetting = true;
                }
                else
                {
                    eventzuttotimer -= Time.deltaTime;
                    if (EventManager.Event.divi == this)
                    {
                        EventManager.Event.eventimer.text = eventzuttotimer.ToString("F1");
                    }

                    if (eventzuttotimer < 0)
                    {
                        if (eventzuttotimer < 0)
                        {
                            EventManager.Event.Return();
                        }
                        Clear();
                    }
                }
            }
            else
            {
                eventalim.SetActive(false);
            }
        }
        

        //hogamdoT.text = $"<b><color=#FF407F>{my.hogamdo.ToString("F1")}/s</color><b>";
    }

    public void Clear()
    {
        eventzuttotimer = 0;
        myevent = null;
        uipos = Vector2.zero;
        eventalim.SetActive(false);

        timersetting = false;
        zuttotimersetting = false;
    }
}
