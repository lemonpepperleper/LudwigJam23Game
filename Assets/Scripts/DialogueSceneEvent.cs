using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSceneEvent : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public Button button;
    public bool dialogueStarted;


    private void Start()
    {
        dialogueStarted = false;
    }

    private void Update()
    {
        if (dialogueStarted)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                button.onClick.Invoke();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dialogueStarted)
        {
            dialogueTrigger.TriggerDialogue();
            dialogueStarted = true;
        }


    }
}
