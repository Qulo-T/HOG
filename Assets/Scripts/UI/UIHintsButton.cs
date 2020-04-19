using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHintsButton : MonoBehaviour
{
    public static UIHintsButton Instance;

    [SerializeField] private Hints hints;
    [SerializeField] private Button backLightButton;

    private Player player;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        player = Player.Instance;
    }

    public void BackLight()
    {
        DecreaseHintsCount();
        hints.Backlight();
        CheckHintsCount();
    }

    private void DecreaseHintsCount()
    {
        player.DecreaseHint();
        UImanager.Instance.UITop.SetHint();
    }
    private void CheckHintsCount()
    {
        if (player.hintCount < 1)
        {
            backLightButton.interactable = false;
        }
    }

    public void Restart()
    {
        backLightButton.interactable = true;
    }

}
