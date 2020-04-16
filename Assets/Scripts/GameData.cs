using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    
    [SerializeField] private bool useConfig;

    [Header("Levels")]
    [SerializeField, Tooltip("first = 0")] private int startLevel;
    [SerializeField] private GameObject[] levelsSpace;
    [SerializeField] private GameObject[] levelsItem;
    [SerializeField] private float[] lvlTimerSEC; //cfg
    [SerializeField] private int[] lvlItemsCount; //cfg
    [SerializeField] private int[] lvlQuestCount; //cfg
    [SerializeField] private int[] lvlEnergyStart; //cfg

    [Header("Player")]
    [SerializeField] private int plHintMax; //cfg
    [SerializeField] private int plEnergyMax; //cfg
    [SerializeField] private float penaltyCount; //cfg

    private static int _startLevel;
    public static int currentLevel { get; private set; }

    private static GameObject[] _levelsSpace;
    private static GameObject[] _levelsItem;
    private static float[] _lvlTimerSEC;
    private static int[] _lvlItemsCount; //max item to be placed. Параметр К в ТЗ
    private static int[] _lvlQuestCount; //items to search, count. 
    private static int[] _lvlEnergyStart;

    public static int _plHintMax { get; private set; }
    public static int _plEnergyMax { get; private set; }
    public static float _penaltyCount { get; private set; }

    void Awake()
    {
        _startLevel = startLevel;
        currentLevel = startLevel;
        _levelsSpace = levelsSpace;
        _levelsItem = levelsItem;

        if (useConfig)
        {
            UseConfig();
        }
        else
        {
            Init();
        }

    }

    private void Init()
    {
        _lvlTimerSEC = lvlTimerSEC;
        _lvlItemsCount = lvlItemsCount;
        _lvlQuestCount = lvlQuestCount;
        _lvlEnergyStart = lvlEnergyStart;
        _plHintMax = plHintMax;
        _plEnergyMax = plEnergyMax;
        _penaltyCount = penaltyCount;
    }
    private void UseConfig()
    {
        //timer
        //itemCount
        //QuestCount
        //lvlEnergyStart
        //plHintMax
        //plEnergyMax
    }
    public static void NextLevel()
    {
        //Проверка есть ли все необходимое для след уровня!
        currentLevel++;
    }
    public static void RestartLvl()
    {
        currentLevel = _startLevel;
    }
    public static List<GameObject> GetLvlSpaces
    {
        get
        {
            List<GameObject> result = GLtools.GetChild(_levelsSpace[currentLevel]);
            return GLtools.Shuffle(result);
        }
    }
    public static List<GameObject> GetLvlItems
    {
        get
        {
            List<GameObject> result = GLtools.GetChild(_levelsItem[currentLevel]);
            return GLtools.Shuffle(result);
        }
    }
    public static float GetTimer { get { return _lvlTimerSEC[currentLevel]; } }
    public static int GetItemsCount { get { return _lvlItemsCount[currentLevel]; } }
    public static int GetQuestCount { get { return _lvlQuestCount[currentLevel]; } }
    public static int GetEnergyStart { get { return _lvlEnergyStart[currentLevel]; } }




}
