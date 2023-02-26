using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;
    public bool loading;

    //private void Start()
    //{
    //    loading = false;
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!loading)
    //    {
    //        LoadNextScene();
    //    }
    //}

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        animator.SetTrigger("Start");
        loading = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
