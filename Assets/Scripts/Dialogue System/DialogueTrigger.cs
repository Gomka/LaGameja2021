using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable
{
    public Dialogue dialogue;
    private DialogueManager dManager;

    private void Awake()
    {
        dManager = FindObjectOfType<DialogueManager>();

    }

    public override void Interact()
    {
        if (inside){
            if(!dManager.isInteracting)
            {
                dManager.StartDialogue(dialogue);
            } else
            {
                dManager.DisplayNextSentence();
            }
        }
    }

    public override void Exit()
    {
        dManager.EndConversation();

    }
}
