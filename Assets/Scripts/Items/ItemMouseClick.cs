using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMouseClick : MonoBehaviour
{
    private static bool falseClick;
    [HideInInspector] public bool quest;
    private void Awake()
    {
        falseClick = false;
        quest = false;
    }
            
    private void OnMouseDown()
    {
        if (quest)
        {
            //удаляем из levelManager.instance.questItem
            //заполняем заного UI questpanel
            //проверяем "победа?"
            
        }
        else
        {
            if (!falseClick)
            {
                falseClick = true;
            }
            else
            {
                //минус 10 сек
                falseClick = false;
            }
        }

    }
}
