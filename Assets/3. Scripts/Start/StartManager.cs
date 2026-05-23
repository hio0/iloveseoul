using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] CanvasGroup fadein;
    [SerializeField] float fadeintime;

    bool isclick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isclick)
        {
            Action action = () => SceneManager.LoadScene("Main");
            StartCoroutine(UIMovement.UIMove.FadeIn(fadein, fadeintime, action));
            isclick = true;
        }
    }
}
