using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public SceneLoader loader;
    public static DeathScreenManager instance;
    public GameObject deathScreen;

    private void Awake()
    {
        if (DeathScreenManager.instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        loader.ReloadScene();
    }
}
