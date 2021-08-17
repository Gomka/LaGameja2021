using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text npcName, dialogueText;

    private Queue<string> sentences;

    private AudioSource audioSource;

    public Animator animator;

    public bool isInteracting= false;

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
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            audioSource.pitch = Random.Range(0, 2);
            audioSource.Play();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        isInteracting=false;
    }
}
