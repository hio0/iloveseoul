using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionControl : MonoBehaviour
{
    public Division my;

    public GameObject eventalim;
    [SerializeField]float eventimer;
    [SerializeField] float eventzuttotimer;
    bool timersetting;

    // Start is called before the first frame update
    void Start()
    {
        eventalim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!timersetting)
        {
            eventimer = Random.Range(5f, 45f);
            timersetting = true;
        }
        else
        {
            eventimer -= Time.deltaTime;

            if(eventimer < 0)
            {
                eventimer = 0;
                eventalim.SetActive(true);
            }
        }

        if(eventalim.activeSelf && eventzuttotimer == 0)
        {
            eventzuttotimer = Random.Range(15f, 30f);
        }

        eventzuttotimer -= Time.deltaTime;
        if (eventzuttotimer < 0)
        {
            eventzuttotimer = 0;
            eventalim.SetActive(false);

            timersetting = false;
        }
    }
}
