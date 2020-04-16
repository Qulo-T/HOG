using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    private List<GameObject> emptySpaces;
    private List<GameObject> itemsPrefab;
    private int maxItem; //параметр К из ТЗ
    public List<GameObject> levelItems { get; private set; }

    private GameObject currentSpace;

    public void Init()
    {
        levelItems = new List<GameObject>();

        itemsPrefab = new List<GameObject>(LevelManager.Instance.itemsPrefab); //клонируем
        emptySpaces = LevelManager.Instance.spaces;
        maxItem = LevelManager.Instance.maxItem;

        if (maxItem > emptySpaces.Count)
        {
            maxItem = emptySpaces.Count;
        }      
    }
    public void Fill()
    {
        for (int i = 0; i < maxItem; i++)
        {
                currentSpace = emptySpaces[i];
                SearchItem();
        }
    }

    private void SearchItem()
    {
        for (int i = 0; i < itemsPrefab.Count; i++)
        {
            if (TypeCompare(itemsPrefab[i]))
            {
                Create(itemsPrefab[i]);                
                itemsPrefab.RemoveAt(i);
                break;
            }
        }
    }

    private bool TypeCompare(GameObject prefab)
    {
        EmptySpace.Sides side = currentSpace.GetComponent<EmptySpace>().Side;
        Item itemScr = prefab.GetComponent<Item>();

        if (side == EmptySpace.Sides.Floor && itemScr.Floor)
        {           
                return true;           
        }

        if (side == EmptySpace.Sides.Roof && itemScr.Roof)
        {
            return true;
        }

        if (side == EmptySpace.Sides.WallX || side == EmptySpace.Sides.WallZ)
        {
            if (itemScr.Wall)
            {
                return true;
            }
        }

        if (side == EmptySpace.Sides.Box && itemScr.Box)
        {
                return true;
        }
       
        return false;
    }

    private void Create(GameObject prefab) 
    {
        GameObject item = Instantiate(prefab);
        item.transform.SetParent(currentSpace.transform);
        item.transform.position = currentSpace.transform.position;

        item.GetComponent<Item>().ItemRotate();

        levelItems.Add(item);
    }
}
