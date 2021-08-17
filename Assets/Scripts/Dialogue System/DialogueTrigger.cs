using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable
{
    public Dialogue dialogue;

    public override void Interact()
    {
        DialogueManager dManager = FindObjectOfType<DialogueManager>();
        if (inside && !dManager.isInteracting){
            dManager.StartDialogue(dialogue);
        }
    }
}
