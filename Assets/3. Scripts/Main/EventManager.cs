using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
    public GameObject eventpopup;
    public TMP_Text eventT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && eventpopup.activeSelf)
        {
            GameObject obj = EventSystem.current.currentSelectedGameObject;

            if(obj != null && obj.name == "Panel")
            {
                eventpopup.SetActive(false);
            }
        }
    }

    public void EventAlim(RectTransform gb)
    {
        eventpopup.SetActive(true);

        float x = Mathf.Clamp(gb.anchoredPosition.x, -650f, 650f);
        float y = Mathf.Clamp(gb.anchoredPosition.y, -200f, 200f);
        eventpopup.GetComponent<RectTransform>().localPosition = new Vector2(x, y);
    }
}
