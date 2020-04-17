using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private Text menuText;
    [SerializeField] private Text energyText;

    private int energyReq;
    private void Start()
    {
        energyReq = GameData.Instance.GetEnergyStart;
    }
    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        LevelManager.Instance.pause = true;
        energyText.text = "Energy: " + Player.Instance.energyCount;
        menuText.text = "Pause";

        if (energyReq > Player.Instance.energyCount)
        {
            restartButton.GetComponent<Button>().interactable = false;
        }
    }

    public void Resume()
    {
        LevelManager.Instance.pause = false;
        menuPanel.SetActive(false);
    }
    public void Restart()
    {
            Player.Instance.DecreaseEnergy(energyReq);
            Player.Instance.SetHints();
            
            UImanager.Instance.UITop.Restart();
            UImanager.Instance.UIBottom.ClearQuestPanel();

            LevelManager.Instance.Restart();

            resumeButton.SetActive(true);
            Resume();
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver(bool win)
    {
        OpenMenu();
        if (win)
        {
            menuText.text = "Winner!";
            resumeButton.SetActive(false);
            restartButton.SetActive(false);
        }
        else
        {
            menuText.text = "Time is out";
            resumeButton.SetActive(false);
        }

    }


}
