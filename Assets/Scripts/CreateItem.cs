using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    private List<GameObject> emptySpaces;
    private List<GameObject> items;
    private int itemsCount; //параметр К из ТЗ
    public List<GameObject> levelItems { get; }

    private GameObject currentSpace;

    public void Init(List<GameObject> spaces, List<GameObject> allItems, int itemsCountMax)
    {
        emptySpaces = spaces;
        items = allItems;
        itemsCount = itemsCountMax;
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
        for (int i = 0; i < items.Count; i++)
        {
            if (TypeCompare(items[i]))
            {
                Create(items[i]);
                levelItems.Add(items[i]);
                items.RemoveAt(i);
                break;
            }
        }
    }

    private bool TypeCompare(GameObject item)
    {
        EmptySpace.Sides side = currentSpace.GetComponent<EmptySpace>().Side;
        Item itemScr = item.GetComponent<Item>();

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

    private void Create(GameObject item) { }
}
