using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    private DialogueManager dialogueManager;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogueManager.StartDialogue(dialogue);
            Destroy(gameObject);
        }
    }
}
