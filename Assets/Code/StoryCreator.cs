using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class StoryCreator : MonoBehaviour
{
    public NodeScriptable storyNode;
    public GameObject storyUnitPrefab;
    public GameObject historyIconPrefab;

    public GameObject history;

    public static StoryCreator Instance;
    public StoryBadge badges;

    public List<ChoiceNode> firstChoices = new List<ChoiceNode>();

    public GameObject restartButton;

    public UnityEvent doneEvent;

    public List<GameObject> buttons = new List<GameObject>();

    void Start()
    {
        Instance = this;
        //DisplayCurrentStory(Color.white);
    }

    bool firstChoice = false;
    void FirstChoice(Icon choice)
    {
        foreach (var item in firstChoices)
        {
            if (item.iconRef == choice)
            {
                storyNode = item.nextNode;
                break;
            }
        }
    }


    public void IconChosen(Icon choice, Image choiceImg)
    {
        if (!firstChoice)
        {
            FirstChoice(choice);
            firstChoice = true;
            DisplayCurrentStory(choiceImg);
            return;
        }
        foreach (var item in storyNode.choices)
        {
            if (item.iconRef == choice)
            {
                storyNode = item.nextNode;
                DisplayCurrentStory(choiceImg);
                //DisplayHistory(choiceColor);
                if (storyNode.choices.Count == 0)
                {
                    SendChoice.IconSelectable = false;
                    badges.CheckForBadge(item.nextNode);
                    doneEvent.Invoke();
                    restartButton.SetActive(true);
                }
                break;
            }
        }
    }

    public void DisplayCurrentStory(Image choiceImg)
    {
        GameObject obj = GameObject.Instantiate(storyUnitPrefab, transform.position, transform.rotation, transform);
        obj.transform.GetComponentInChildren<TextMeshProUGUI>().text = storyNode.text;
        obj.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = choiceImg.sprite;
        obj.transform.GetChild(1).GetChild(1).GetComponent<Image>().color = choiceImg.color;
        buttons.Add(obj);
    }

    public void DisplayHistory(Color choiceColor)
    {
        GameObject obj = GameObject.Instantiate(historyIconPrefab, transform.position, transform.rotation, history.transform);
        Debug.Log(obj.transform.GetChild(1));
        obj.transform.GetChild(1).GetComponent<Image>().color = choiceColor;
    }

    public void RestartGame(){
        foreach (var item in buttons)
        {
            item.GetComponent<TweenScale>().ScaleToStart();
            item.GetComponent<TweenAlpha>().AlphaTostart();
        }
        Invoke("RestartScene", 0.6f);
    }

    void RestartScene(){
        SendChoice.IconSelectable = true;
        SceneManager.LoadScene(0);

    }
}
