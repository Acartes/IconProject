using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TweenButton : MonoBehaviour
{
    [Header("Settings")]
    public float duration = 0.5f;
    public float delay = 0.5f;

    public AnimationCurve curve = default;

    public GameObject center = default;

    private Vector3 originPos = Vector3.zero;

    [Header("Events")]
    public UnityEvent onCompleteCallback = default;

    public void Start()
    {
        //center = GetComponentInParent<Transform>().gameObject;
        originPos = this.transform.position;
    }

    public void OnComplete()
    {
        if (onCompleteCallback != null)
        {
            onCompleteCallback.Invoke();
        }
    }

    public void MoveToCenter()
    {
        LeanTween.move(this.gameObject, center.transform.position, duration).setDelay(delay).setOnComplete(OnComplete).setEase(curve);
    }

    public void MoveToOrigin()
    {
        LeanTween.move(this.gameObject, originPos, duration).setDelay(delay).setOnComplete(OnComplete).setEase(curve);
    }
}
