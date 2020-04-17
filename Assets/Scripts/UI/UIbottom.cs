using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIBottomButton))]
public class UIbottom : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject questPanel;

    private LevelManager levelManager;
    private Player player;
    private List<GameObject> questItem;
    private void Start()
    {
        levelManager = LevelManager.Instance;
        player = Player.Instance;
    }
    public void Init()
    {
        questItem = levelManager.questItem;
    }

    public void FillQuestPanel()
    {
        for (int i = 0; i < questItem.Count; i++)
        {
            GameObject itemText = Instantiate(textPrefab);
            itemText.transform.SetParent(questPanel.transform);
            itemText.GetComponent<Text>().text = questItem[i].GetComponent<Item>().Name;
        }
    }
    public void ClearQuestPanel()
    {
        int count = questPanel.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(questPanel.transform.GetChild(i).gameObject);
        }
    }


}
