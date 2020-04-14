using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private UImanager uiManager;

    private List<GameObject> itemsPull;

    private int questItemCount; //кол-во для поиска
    private int maxItem; //параметр К в ТЗ

    private List<GameObject> spaces;
    private List<GameObject> levelItems;
    public List<GameObject> questItem { get; private set; }
    
    void Start()
    {
        questItem = new List<GameObject>();
        spaces = GameData.GetLvlSpaces;
        itemsPull = GameData.GetLvlItems;
        maxItem = GameData.GetItemsCount;
        questItemCount = GameData.GetQuestCount;
        
        GetComponent<CreateItem>().Init(spaces, itemsPull, maxItem);
        levelItems = GetComponent<CreateItem>().levelItems;
        Quest();
    }

    private void Quest()
    {
        if (questItemCount > levelItems.Count)
        {
            questItemCount = levelItems.Count;
        }

        levelItems.Reverse(); //согласно ТЗ, последние 3 (questItemCount) - квест
       
        for (int i = 0; i < questItemCount; i++)
        {            
            questItem.Add(levelItems[i]);
        }

    }

}
