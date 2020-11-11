using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TweenScale : MonoBehaviour
{
    [Header("Settings")]
    public bool tweenOnStart = false;
    public Vector3 startScale = new Vector3(0, 0, 0);
    public Vector3 pauseScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 targetScale = new Vector3(1, 1, 1);
    public float duration = 0.5f;

    public bool randomDelay = false;
    public float delay = 0.3f;
    public float maxDelay = 0.3f;

    public AnimationCurve curve = default;

    [Header("Events")]
    public UnityEvent onCompleteCallback = default;

    void OnEnable()
    {
        transform.localScale = startScale;
        if (tweenOnStart)
        {
            Scale();
        }
    }

    public void OnComplete()
    {
        if(onCompleteCallback != null)
        {
            onCompleteCallback.Invoke();
        }
    }

    public void Scale()
    {
        if (randomDelay)
        {
            delay = Random.Range(delay, maxDelay);
        }

        LeanTween.scale(gameObject, targetScale, duration).setDelay(delay).setOnComplete(OnComplete).setEase(curve);
    }

    public void ScaleToStart()
    {
        LeanTween.scale(gameObject, startScale, duration).setDelay(delay).setOnComplete(OnComplete).setEase(curve);
    }

    public void ScaleToPause()
    {
        LeanTween.scale(gameObject, pauseScale, duration).setDelay(delay).setOnComplete(OnComplete).setEase(curve);
    }
}
