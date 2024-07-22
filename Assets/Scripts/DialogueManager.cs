using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;

    private Coroutine currentDialogueCoroutine;

    public void SetDialogue(string text)
    {
        Debug.Log("SetDialogue called with text: " + text); // Add this line
        if (currentDialogueCoroutine != null)
        {
            StopCoroutine(currentDialogueCoroutine);
        }
        currentDialogueCoroutine = StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach(char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
