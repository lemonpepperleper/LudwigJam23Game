using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalEvent : MonoBehaviour
{
    public GameObject madCat;
    public GameObject madCathpBar;

    public GameObject coots;
    public GameObject cootshpBar;

    public GameObject cam;

    public GameObject boulderPrefab;
    public Vector2[] boulderStartingPos;
    public Vector2[] boulderFinalPos;
    public float numOfBoulders;

    public DialogueTrigger beforeDialogue;
    public DialogueTrigger afterDialogue;
    public DialogueTrigger deadDialogue;
    //private bool dialogueStarted;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        numOfBoulders = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            button.onClick.Invoke();
        }
    }

    public void DropBoulders()
    {
        for (int i = 0; i < boulderFinalPos.Length; i++)
        {
            GameObject boulder = Instantiate(boulderPrefab, boulderStartingPos[i], Quaternion.identity);
            boulder.GetComponent<BoulderController>().SetTarget(boulderFinalPos[i]);
            numOfBoulders += 1;
        }
    }


    public void MadCatTransition()
    {
        coots.SetActive(false);
        cootshpBar.SetActive(false);
        madCat.SetActive(true);
        madCathpBar.SetActive(true);
    }

    public void TurnOnCootsCam()
    {
        cam.SetActive(true);
    }

    public void TurnOffCootsCam()
    {
        cam.SetActive(false);
    }
}
