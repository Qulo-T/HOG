using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIbottom), typeof(UItop))]
public class UImanager : MonoBehaviour
{
    public static UImanager Instance { get; private set; }
    public UIbottom uibottom { get; private set; }
    public UItop uitop { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        uibottom = GetComponent<UIbottom>();
        uitop = GetComponent<UItop>();

        uibottom.Init();
        uibottom.FillQuestPanel();

        uitop.SetHint();
    }
}
