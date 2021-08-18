using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text npcName, dialogueText;

    private InputHandler input;

    private Queue<string> sentences;

    private AudioSource audioSource;

    public Animator animator;

    public bool isInteracting= false;

    private MovementController movement;

    void Start()
    {
        sentences = new Queue<string>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if(!isInteracting){

        animator.SetBool("IsOpen", true);

        isInteracting=true;
        movement.StopMovement();
        movement.enabled = false;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        npcName.text = dialogue.npcName;
        audioSource.clip = dialogue.npcVoice;

        DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if(isInteracting)
        {
            if (sentences.Count == 0)
            {
                StartCoroutine(EndDialogue());
                return;
            }

            string sentence = sentences.Dequeue();

            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            audioSource.pitch = Random.Range(-0.5f, 3);
            audioSource.Play();
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator EndDialogue()
    {
        if(isInteracting)
        {
            animator.SetBool("IsOpen", false);
            movement.enabled = true;
            yield return new WaitForSeconds(0.5f);
            isInteracting = false;
        }
    }

    public void EndConversation()
    {
        StartCoroutine(EndDialogue());
    }

    private void Awake()
    {
        movement = FindObjectOfType<MovementController>();
    }
}
