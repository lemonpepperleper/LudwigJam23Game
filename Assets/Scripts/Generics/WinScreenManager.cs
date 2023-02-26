using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public SceneLoader loader;
    public static WinScreenManager instance;
    public GameObject winScreen;

    private void Awake()
    {
        if (WinScreenManager.instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        loader.ReloadScene();
    }
}
