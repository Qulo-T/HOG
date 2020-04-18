using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Linq;

public class XMLRead : MonoBehaviour
{
    [SerializeField] private string fileName;
    private string path;

    public List<float> lvlTimerSEC { get; private set; } = new List<float>();
    public List<int> lvlItemsCount { get; private set; } = new List<int>();
    public List<int> lvlQuestCount { get; private set; } = new List<int>();
    public List<int> lvlEnergyStart { get; private set; } = new List<int>();

    public int plHintMax { get; private set; }
    public int plEnergyMax { get; private set; }
    public float penaltyCount { get; private set; }

    public void Init()
    {
        path = Application.dataPath + "/" + fileName;
    }

    public void Load()
    {
        XElement levels = null;
        XElement player = null;

        if (File.Exists(path))
        {
            levels = XDocument.Parse(File.ReadAllText(path)).Element("GameData").Element("Chapter0");
            player = XDocument.Parse(File.ReadAllText(path)).Element("GameData").Element("Player");
        }
        UnpackLevels(levels);
        UnpackPlayer(player);
    }

    private void UnpackLevels(XElement levels)
    {
        List<XElement> level = new List<XElement>();

        foreach (XElement element in levels.Elements("level"))
        {
            level.Add(element);
        }

        for (int i = 0; i < level.Count; i++)
        {
            lvlTimerSEC.Add(float.Parse(level[i].Attribute("timer").Value));
            lvlItemsCount.Add(int.Parse(level[i].Attribute("ItemCount").Value));
            lvlQuestCount.Add(int.Parse(level[i].Attribute("QuestCount").Value));
            lvlEnergyStart.Add(int.Parse(level[i].Attribute("Energy").Value));
        }
    }
    private void UnpackPlayer(XElement player)
    {
        XElement data = player.Element("data");

        plHintMax = int.Parse(data.Attribute("Hints").Value);
        plEnergyMax = int.Parse(data.Attribute("Energy").Value);
        penaltyCount = float.Parse(data.Attribute("Penalty").Value);
    }
}
