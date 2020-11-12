using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Ending
{
    public NodeScriptable node;
    public AudioClip clip;
}

public class MusicEndings : MonoBehaviour
{
    public List<Ending> endings = new List<Ending>();
    public AudioSource musicSource;
    public void CheckForEnding(NodeScriptable node)
    {
        Ending foundNode = endings.Find(x=> x.node == node);
        if(foundNode != null){
            musicSource.clip = foundNode.clip;
            musicSource.Play();
        }
    }
}
