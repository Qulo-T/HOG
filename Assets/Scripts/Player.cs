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
    }
    public void Start()
    {
        hintMax = GameData._plHintMax;
        hintCount = hintMax;

        energyMax = GameData._plEnergyMax;
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



}
