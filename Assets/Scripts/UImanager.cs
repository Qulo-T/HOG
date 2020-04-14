using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [SerializeField] private GameObject levelManager;
    [SerializeField] private GameObject player;
    public void Init()
    {
        GetComponent<UIbottom>().Init(levelManager,player);
    }
}
