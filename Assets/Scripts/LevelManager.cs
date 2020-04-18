using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CreateItem))]

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public List<GameObject> itemsPrefab { get; private set; }
    public List<GameObject> spaces { get; private set; }
    public List<GameObject> questItem { get; private set; }
    public int maxItem { get; private set; } //параметр К в ТЗ

    private CreateItem createItem;
    private List<GameObject> levelItems;
    private int questItemCount; //кол-во для поиска

    public bool pause;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        pause = false;

        questItem = new List<GameObject>();

        spaces = GameData.Instance.GetLvlSpaces;
        itemsPrefab = GameData.Instance.GetLvlItems;
        maxItem = GameData.Instance.GetItemsCount;
        questItemCount = GameData.Instance.GetQuestCount;
        createItem = GetComponent<CreateItem>();

        Run();
    }
    public void Run()
    {
        createItem.Init();
        createItem.Fill();

        levelItems = createItem.levelItems;
        Quest();

        UImanager.Instance.Init();
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
            levelItems[i].GetComponent<ItemMouseClick>().quest = true;
            questItem.Add(levelItems[i]);
        }

    }
    public void RemoveQuestItem(GameObject item)
    {
        questItem.Remove(item);
        if (questItem.Count < 1)
        {
            GameOver(true);
        }
    }
    public void Restart() 
    {
        for (int i = 0; i < levelItems.Count; i++)
        {
            Destroy(levelItems[i]);
        }
        questItem.Clear();
        Start();
    }
    public void GameOver(bool win)
    {
        if (win)
        {
            UImanager.Instance.UIMenu.GameOver(true);
        }
        else
        {
           
            SoundManager.Instance.TimeOut();
            UImanager.Instance.UIMenu.GameOver(false);
        }
    }

}
