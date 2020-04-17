using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItop : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text hintText;
    [SerializeField] private GameObject penltyPrefab;

    private float time;
    private float penaltyCount;
    public void Start()
    {
        time = GameData.Instance.GetTimer;
        penaltyCount = GameData.Instance.GetPenaltyCount;
    }

    private void Update()
    {
        if (time > 0)
        {
            Timer();
        }
        else
        {
            time = 0;
            LevelManager.Instance.GameOver(false);
        }
    }
    public void Timer()
    {
        if (!LevelManager.Instance.pause)
        {
            int minute = (int)time / 60;
            int seconds = (int)time % 60;

            string txt = string.Format("{0:0}:{1:00}", minute, seconds);
            timerText.text = txt;
            time -= Time.deltaTime;
        }
    }
    public void SetHint()
    {
        hintText.text = "Hints: " + Player.Instance.hintCount;
    }
    public void Penalty()
    {
        time -= penaltyCount;
        GameObject penaltyView = Instantiate(penltyPrefab);
        penaltyView.transform.SetParent(gameObject.transform);
        penaltyView.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 30);
    }
    public void Restart()
    {
        time = GameData.Instance.GetTimer;
    }
}
