using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItop : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text hintText;

    private float time;
    private float penaltyCount;
    public void Start()
    {
        time = GameData.Instance.GetTimer;
        penaltyCount = GameData.Instance.GetPenaltyCount;
    }

    private void Update()
    {        
        int minute = (int) time / 60;
        int seconds = (int) time % 60;

        string txt = string.Format("{0:0}:{1:00}", minute, seconds);
        timerText.text = txt;
        time -= Time.deltaTime;
    }

    public void SetHint()
    {
        hintText.text = "Hints: " + Player.Instance.hintCount;
    }
    public void Penalty()
    {
        time -= penaltyCount;
        //создание текст префаба
    }
}
