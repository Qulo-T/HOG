using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    private List<GameObject> emptySpaces;
    private List<GameObject> prefabs;
    private int itemsCount; //параметр К из ТЗ
    public List<GameObject> levelItems { get; private set; }

    private GameObject currentSpace;

    public void Init(List<GameObject> spaces, List<GameObject> allItems, int itemsCountMax)
    {
        levelItems = new List<GameObject>();
        prefabs = new List<GameObject>(allItems); //клонируем

        emptySpaces = spaces;
        itemsCount = itemsCountMax;

        if (itemsCount > emptySpaces.Count)
        {
            itemsCount = emptySpaces.Count;
        }

        Fill();

    }
    private void Fill()
    {
        for (int i = 0; i < itemsCount; i++)
        {
                currentSpace = emptySpaces[i];
                SearchItem();
        }
    }

    private void SearchItem()
    {
        for (int i = 0; i < prefabs.Count; i++)
        {
            if (TypeCompare(prefabs[i]))
            {
                Create(prefabs[i]);
                levelItems.Add(prefabs[i]);
                prefabs.RemoveAt(i);
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
    }
}
