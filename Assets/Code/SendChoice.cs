using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SendChoice : MonoBehaviour
{
    public Icon choice;

    public Image choiceImg;

    public static bool IconSelectable = true;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(!IconSelectable){
            GetComponent<Button>().interactable = false;
        }
    }
    public void applyChoice()
    {
        StoryCreator.Instance.IconChosen(choice, choiceImg.color);
        GetComponent<Button>().interactable = false;

        //do anim stuff
        ParticleAnim.instance.PlayAnim(this.gameObject);
    }
}
