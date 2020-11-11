using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TweenMove : MonoBehaviour
{
    [Header("Settings")]
    public bool moveOnStart = false;
    public float duration = 0.5f;
    public float delay = 0.3f;

    public float yOffset = 25;

    public AnimationCurve curve = default;

    [Header("Events")]
    public UnityEvent onCompleteCallback = default;

    void OnEnable()
    {
        if (moveOnStart)
        {
            Move();
        }
    }

    public void OnComplete()
    {
        if (onCompleteCallback != null)
        {
            onCompleteCallback.Invoke();
        }
    }

    public void Move()
    {
        float yOrigin = this.gameObject.transform.position.y;
        LeanTween.moveLocalY(this.gameObject, this.gameObject.transform.position.y + yOffset, duration).setDelay(delay).setOnComplete(OnComplete).setEase(curve);
    }
}
