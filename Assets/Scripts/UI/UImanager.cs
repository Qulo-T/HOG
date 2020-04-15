using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIbottom),typeof(UItop))]
public class UImanager : MonoBehaviour
{
    public static UImanager Instans { get; private set; }

    private void Awake()
    {
        Instans = this;
    }
    public void Init()
    {
        GetComponent<UIbottom>().Init();
    }
}
