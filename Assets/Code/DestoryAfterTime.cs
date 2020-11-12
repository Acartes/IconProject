using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfterTime : MonoBehaviour
{
    public float delay = 1f;
    void Start()
    {
        Destroy(this.gameObject, delay);
    }
}
