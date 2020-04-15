using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbottom : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject questPanel;

    private LevelManager levelManager;
    private Player player;
    private List<GameObject> questItem;
    public void Init()
    {
        levelManager = LevelManager.Instance;
        player = Player.Instance;

        questItem = levelManager.questItem;

        FillQuestanel();

    }
    private void FillQuestanel()
    {
        for (int i = 0; i < questItem.Count; i++)
        {
            GameObject itemText = Instantiate(textPrefab);
            itemText.transform.SetParent(questPanel.transform);
            itemText.GetComponent<Text>().text = questItem[i].GetComponent<Item>().Name;
        }

    }


}
