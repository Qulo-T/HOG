using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyView : MonoBehaviour
{
    [SerializeField] private float timer;

    private float penaltyCount;

    private void Start()
    {
        penaltyCount = GameData.Instance.GetPenaltyCount;
        StartCoroutine(SelfDestroy());
    }
    void Update()
    {
        Color color = GetComponent<Text>().color;
        color.a -= (0.5f *Time.deltaTime);
        GetComponent<Text>().color = color;
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
