using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryCreator : MonoBehaviour
{
    public NodeScriptable storyNode;
    public GameObject storyUnitPrefab;
    public GameObject historyIconPrefab;

    public GameObject history;

    public static StoryCreator Instance;
    public StoryBadge badges;

    void Start()
    {
        Instance = this;
        //DisplayCurrentStory(Color.white);
    }

    public void IconChosen(Icon choice, Color choiceColor)
    {
        foreach (var item in storyNode.choices)
        {
            if (item.iconRef == choice)
            {
                storyNode = item.nextNode;
                DisplayCurrentStory(choiceColor);
                //DisplayHistory(choiceColor);
                if(storyNode.choices.Count == 0){
                    SendChoice.IconSelectable = false;
                    badges.CheckForBadge(item.nextNode);
                }
                break;
            }
        }
    }

    public void DisplayCurrentStory(Color choiceColor)
    {
        GameObject obj = GameObject.Instantiate(storyUnitPrefab, transform.position, transform.rotation, transform);
        obj.transform.GetComponentInChildren<TextMeshProUGUI>().text = storyNode.text;
        obj.transform.GetChild(1).GetChild(1).GetComponent<Image>().color = choiceColor;
    }

    public void DisplayHistory(Color choiceColor)
    {
        GameObject obj = GameObject.Instantiate(historyIconPrefab, transform.position, transform.rotation, history.transform);
        Debug.Log(obj.transform.GetChild(1));
        obj.transform.GetChild(1).GetComponent<Image>().color = choiceColor;
    }
}
