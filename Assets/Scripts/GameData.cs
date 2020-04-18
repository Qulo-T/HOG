using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    [Header("config")]
    [SerializeField] private XMLRead xml;
    [SerializeField] private bool useConfig;

    [Header("Levels")]
    [SerializeField, Tooltip("first = 0")] private int startLevel;
    [SerializeField] private GameObject[] levelsSpace;
    [SerializeField] private GameObject[] levelsItem;
    [SerializeField] private List<float> lvlTimerSEC; //cfg
    [SerializeField] private List<int> lvlItemsCount; //cfg, max item to be placed. Параметр К в ТЗ
    [SerializeField] private List<int> lvlQuestCount; //cfg, items to search, count.
    [SerializeField] private List<int> lvlEnergyStart; //cfg

    [Header("Player")]
    [SerializeField] private int plHintMax; //cfg
    [SerializeField] private int plEnergyMax; //cfg
    [SerializeField] private float penaltyCount; //cfg

    public int currentLevel { get; private set; }

    void Awake()
    {
        Instance = this;
        currentLevel = startLevel;

        if (useConfig)
        {
            UseConfig();
        }

    }

    private void UseConfig()
    {
        xml.Init();
        xml.Load();

        lvlTimerSEC = xml.lvlTimerSEC;
        lvlItemsCount = xml.lvlItemsCount;
        lvlQuestCount = xml.lvlQuestCount;
        lvlEnergyStart = xml.lvlEnergyStart;

        plHintMax = xml.plHintMax;
        plEnergyMax = xml.plEnergyMax;
        penaltyCount = xml.penaltyCount;
    }
    public void NextLevel()
    {
        //Проверка есть ли все необходимое для след уровня!
        currentLevel++;
    }
    public void RestartLvl()
    {
        currentLevel = startLevel;
    }
    public List<GameObject> GetLvlSpaces
    {
        get
        {
            List<GameObject> result = GLtools.GetChild(levelsSpace[currentLevel]);
            return GLtools.Shuffle(result);
        }
    }
    public List<GameObject> GetLvlItems
    {
        get
        {
            List<GameObject> result = GLtools.GetChild(levelsItem[currentLevel]);
            return GLtools.Shuffle(result);
        }
    }
    public float GetTimer { get { return lvlTimerSEC[currentLevel]; } }
    public int GetItemsCount { get { return lvlItemsCount[currentLevel]; } }
    public int GetQuestCount { get { return lvlQuestCount[currentLevel]; } }
    public int GetEnergyStart { get { return lvlEnergyStart[currentLevel]; } }
    public int GetPlHintMax { get { return plHintMax; } }
    public int GetPlEnergyMax { get { return plEnergyMax; } }
    public float GetPenaltyCount { get { return penaltyCount; } }




}
