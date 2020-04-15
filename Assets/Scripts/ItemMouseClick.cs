using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMouseClick : MonoBehaviour
{
    private static bool falseClick;
    [HideInInspector] public bool quest;
    private void Awake()
    {
        falseClick = false;
        quest = false;
    }
            
    private void OnMouseDown()
    {
        Debug.Log("click");
    }
}
