using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private UIMenuButton uIMenuButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Escape();
        }
    }

    private void Escape()
    {
        uIMenuButton.MenuButton();
    }
}
