using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbottom : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject questPanel;

    private GameObject levelManager;
    private GameObject player;
    public void Init(GameObject levelManager, GameObject player)
    {
        this.levelManager = levelManager;
        this.player = player;
    }


}
