using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public static UImanager Instance { get; private set; }
    [SerializeField] private UIbottom uibottom;
    [SerializeField] private UItop uitop;
    [SerializeField] private UIMenuButton uiMenu;

    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        uibottom.Init();
        uibottom.FillQuestPanel();

        uitop.SetHint();
    }

    public UIbottom UIBottom { get { return uibottom; } }
    public UItop UITop { get { return uitop; } }
    public UIMenuButton UIMenu { get { return uiMenu; } }
}
