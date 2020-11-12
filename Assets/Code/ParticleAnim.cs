using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAnim : MonoBehaviour
{
    public Animator anim = default;
    public float rotation = 10;
    public static ParticleAnim instance = default;

    public void Awake()
    {
        instance = this;
    }

    public void PlayAnim(GameObject targetPos)
    {
        transform.Rotate(0, 0, 0 + Random.Range(-rotation,rotation));
        LeanTween.move(this.gameObject, targetPos.transform.position, 0f);
        anim.SetTrigger("pop");
    }
}