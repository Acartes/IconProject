using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class GoodEnding
{
    public string choiceNodeName;
    public Sprite badge;
}

public class StoryBadge : MonoBehaviour
{
    public List<GoodEnding> endings = new List<GoodEnding>();
    public GameObject BadgePrefab;
    public void CheckForBadge(NodeScriptable node)
    {
        Debug.Log(node);
        foreach (var item in endings)
        {
            Debug.Log(node.ToString());
            if (node.ToString().Split(' ')[0] == item.choiceNodeName)
            {
                GameObject obj = GameObject.Instantiate(BadgePrefab, transform.position, transform.rotation, transform);
                obj.transform.GetComponent<Image>().sprite = item.badge;
            }
        }
    }
}
