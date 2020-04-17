using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public void Backlight()
    {
        List<GameObject> questItems = LevelManager.Instance.questItem;
        int count = questItems.Count;
        int rnd = Random.Range(0, count);
        questItems[rnd].GetComponent<Item>().BackLight();

    }
}
