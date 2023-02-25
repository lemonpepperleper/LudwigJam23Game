using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> names;

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;

    public float typingSpeed;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue[] dialogues)
    {
        animator.SetBool("isOpen", true);
        Time.timeScale = 0;
        sentences.Clear();

        foreach (var dialogue in dialogues)
        {
            sentences.Enqueue(dialogue.sentence);
            names.Enqueue(dialogue.name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        nameText.text = name;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Time.timeScale = 1;
    }
}
