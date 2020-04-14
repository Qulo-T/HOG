using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLtools : MonoBehaviour
{
    public static List<T> Shuffle<T>(List<T> list)
    {
        List<T> result = list;
        for (int i = 0; i < result.Count; i++)
        {
            T tmp = result[i];
            int rnd = Random.Range(0, result.Count);
            result[i] = result[rnd];
            result[rnd] = tmp;
        }

        return result;
    }

    public static List<GameObject> GetChild(GameObject parent)
    {
        int childCoint = parent.transform.childCount;
        List<GameObject> list = new List<GameObject>();       

        for (int i = 0; i < childCoint; i++)
        {
            list.Add( parent.transform.GetChild(i).gameObject);
        }

        return list;
    }
}
