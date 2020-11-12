using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthenB : MonoBehaviour
{
    public AudioSource source;
    public AudioClip a;
    public AudioClip b;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
            source.clip = b;
            source.loop = true;
        }

    }
}
