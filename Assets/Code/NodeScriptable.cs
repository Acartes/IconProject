using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public enum Icon
{
    Human,
    Nature,
    Knife,
    Love
}

[System.Serializable]
public class ChoiceNode
{
    public Icon iconRef;
    public NodeScriptable nextNode;
}

[CreateAssetMenu(fileName = "StoryNode", menuName = "StoryNode", order = 1)]
public class NodeScriptable : ScriptableObject
{
    public string text;
[SerializeField]
    public List<ChoiceNode> choices = new List<ChoiceNode>();

}