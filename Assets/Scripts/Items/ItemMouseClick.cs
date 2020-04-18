using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMouseClick : MonoBehaviour
{
    public static bool falseClick;
    [HideInInspector] public bool quest;
    void Awake()
    {
        falseClick = false;
        quest = false;
    }
            
    private void OnMouseDown()
    {
        if (quest)
        {
            falseClick = false;

            LevelManager.Instance.RemoveQuestItem(gameObject);
            
            UImanager.Instance.UIBottom.ClearQuestPanel();
            UImanager.Instance.UIBottom.FillQuestPanel();

            Destroy(gameObject);

            SoundManager.Instance.QuestClick();
        }
        else
        {
            if (!falseClick)
            {
                falseClick = true;
            }
            else
            {
                UImanager.Instance.UITop.Penalty();
                SoundManager.Instance.FalseClick();
                falseClick = false;
            }
        }

    }
}
