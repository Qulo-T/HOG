using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int numScene;
    public void LoadScene()
    {
        SceneManager.LoadScene(numScene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
