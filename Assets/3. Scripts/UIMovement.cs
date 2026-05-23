using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMovement : MonoBehaviour
{
    public static UIMovement UIMove;

    public CanvasGroup fadeP;

    private void Awake()
    {
        if (UIMove == null)
        {
            UIMove = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(fadeP.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator FadeIn(CanvasGroup what, float fadeoutime, Action action)
    {
        what.alpha = 0f;
        float startalpha = what.alpha;
        float plus = 0f;

        while (what.alpha < 1)
        {
            plus += Time.deltaTime;

            what.alpha += Mathf.Lerp(startalpha, 1f, plus / fadeoutime);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        action?.Invoke();
    }

    public IEnumerator FadeOut(CanvasGroup what, float fadeoutime, Action action)
    {
        what.alpha = 1f;
        float startalpha = what.alpha;
        float minus = 0f;

        while (what.alpha > 0)
        {
            minus += Time.deltaTime;

            what.alpha -= Mathf.Lerp(startalpha, 0f, minus / fadeoutime);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        action?.Invoke();
    }
}
