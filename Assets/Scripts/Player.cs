using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private int hintMax;
    public int hintCount { get; private set; }

    private int energyMax;
    public int energyCount { get; private set; }

    void Awake()
    {
        Instance = this;

        hintMax = GameData.Instance.GetPlHintMax;
        SetHints();

        energyMax = GameData.Instance.GetPlEnergyMax;
        energyCount = energyMax;
    }

    public void DecreaseEnergy(int count)
    {
        energyCount -= count;
    }

    public void DecreaseHint()
    {
        hintCount--;
    }
    public void SetHints()
    {
        hintCount = hintMax;
    }



}
