using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    public static DialogueSystem Instance { get; set; }
    public GameObject DialoguePanel;
    [HideInInspector]
    public List<string> dialogueLines = new List<string>();
    [HideInInspector]
    public string npcName;

    Button continueButton;
    Text dialogueText, nameText; // the comma allows you to declare multuple variables of the same time, keeping it in one line.
    int dialogueIndex;

    private void Awake()
    {
        continueButton = DialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = DialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = DialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        DialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
        }
    }
    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        this.npcName = npcName;

        Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        DialoguePanel.SetActive(true);

    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            DialoguePanel.SetActive(false);

        }


    }
}