using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] allItems;
    [SerializeField] private GameObject spaces;
    [SerializeField] private int questItemCount;

    private GameObject[] itemSpaces;
    public List<GameObject> levelItem;
    public List<GameObject> currentItem;
    void Start()
    {
        itemSpaces = GetChild(spaces);
        itemSpaces = Shuffle(itemSpaces);
        allItems = Shuffle(allItems);

        CreateItem();
        SelectItem();

    }


    private void CreateItem()
    {
        for (int i = 0; i < itemSpaces.Length; i++)
        {
            if (i<allItems.Length)
            {
                GameObject item = Instantiate(allItems[i]);
                item.transform.SetParent(itemSpaces[i].transform);
                item.transform.position = itemSpaces[i].transform.position;

                item.GetComponent<Item>().ItemRotate();
                levelItem.Add(item);
            }
        }
    }

    private void SelectItem()
    {
        for (int i = 0; i < questItemCount; i++)
        {
            currentItem.Add(levelItem[levelItem.Count - 1 - i]);
        }

    }

    private GameObject[] Shuffle(GameObject[] mss)
    {
        GameObject[] result = mss;
        for (int i = 0; i < result.Length; i++)
        {
            GameObject tmp = result[i];
            int rnd = Random.Range(0, result.Length);
            result[i] = result[rnd];
            result[rnd] = tmp;
        }

        return result;
    }
    private GameObject[] GetChild(GameObject parent) 
    {
        int childCoint = parent.transform.childCount;
        GameObject[] mss = new GameObject[childCoint];

        for (int i = 0; i < childCoint; i++)
        {
            mss[i] = parent.transform.GetChild(i).gameObject;
        }

        return mss;
    }

}
