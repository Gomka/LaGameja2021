using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabSentado : Interactable
{
    public Dialogue[] dialogue;
    private DialogueManager dManager;

    private void Awake()
    {
        dManager = FindObjectOfType<DialogueManager>();
    }

    public override void Interact()
    {
        if (inside && !dManager.isInteracting)
        {
            dManager.StartDialogue(dialogue[Random.Range(0,dialogue.Length)]);
        }
    }

    public override void Exit()
    {
        dManager.EndConversation();
    }

}
