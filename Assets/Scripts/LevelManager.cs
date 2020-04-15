﻿using System.Collections;
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

    private List<GameObject> levelItems;
    private int questItemCount; //кол-во для поиска


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        questItem = new List<GameObject>();

        spaces = GameData.GetLvlSpaces;
        itemsPrefab = GameData.GetLvlItems;
        maxItem = GameData.GetItemsCount;
        questItemCount = GameData.GetQuestCount;
        
        GetComponent<CreateItem>().Init();

        levelItems = GetComponent<CreateItem>().levelItems;
        Quest();
        UImanager.Instans.Init();
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
