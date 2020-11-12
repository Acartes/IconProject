using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public GameObject popSound = default;
    public float maxPitch = 0.1f;

    public static PlaySound instance = default;

    public void Awake()
    {
        instance = this;
    }

    public void PlayPopSound()
    {
        GameObject audioSource = Instantiate(popSound, this.transform.position, Quaternion.identity);
        audioSource.transform.SetParent(this.transform);
        AudioSource curSource = audioSource.GetComponent<AudioSource>();
        curSource.pitch = 1 + Random.Range(-maxPitch, maxPitch);
        curSource.Play();
    }
}
