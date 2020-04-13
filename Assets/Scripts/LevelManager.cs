using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> allItems;
    [SerializeField] private GameObject spaceBox;

    [SerializeField] private int questItemCount; //кол-во для поиска
    [SerializeField] private int maxItem; //параметр К в ТЗ

    private List<GameObject> spaces;
    public List<GameObject> levelItems;
    
    void Start()
    {
        spaces = GLtools.GetChild(spaceBox);
        spaces = GLtools.Shuffle(spaces);

        allItems = GLtools.Shuffle(allItems);

        GetComponent<CreateItem>().Init(spaces, allItems, maxItem);
        levelItems = GetComponent<CreateItem>().levelItems;
    }
}
