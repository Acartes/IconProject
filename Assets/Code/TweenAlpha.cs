using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class TweenAlpha : MonoBehaviour
{
    [Header("Settings")]
    public bool tweenOnStart = false;

    public float startAplha = 0;
    public float targetAlpha = 1;

    public float duration = 0.5f;

    public AnimationCurve curve = default;

    public CanvasGroup canvasGroup = default;

    private float n = 0;
    private bool alphaToStart = false;

    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = startAplha;
        
    }

    public void FixedUpdate()
    {
        if (tweenOnStart && n < duration)
        {
            canvasGroup.alpha += curve.Evaluate(n / duration);
            n += Time.deltaTime;
        }
        else
        {
            if (alphaToStart)
            {
                canvasGroup.alpha += curve.Evaluate(n / duration);
                n -= Time.deltaTime;
            }
        }
        
    }

    public void AlphaTostart()
    {
        alphaToStart = true;
    }
}
