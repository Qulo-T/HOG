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

            Debug.Log("клик квест");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("клик");
            if (!falseClick)
            {
                falseClick = true;
            }
            else
            {
                UImanager.Instance.UITop.Penalty();
                falseClick = false;
                Debug.Log("штраф");
            }
        }

    }
}
