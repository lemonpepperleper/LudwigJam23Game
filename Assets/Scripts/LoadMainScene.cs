using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    public SceneLoader loader;
    public bool loading;

    private void Start()
    {
        loading = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!loading)
        {
            loading = true;
            loader.LoadNextScene();
        }
    }
}
