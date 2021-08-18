using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI npcName, dialogueText;

    private DialogueNode currentNode;

    private AudioSource audioSource;

    public Animator animator;

    public bool isInteracting = false;

    private MovementController movement;

    [SerializeField] private Button defaultButton, bOption1, bOption2, bOption3;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if(!isInteracting){

            animator.SetBool("IsOpen", true);

            isInteracting=true;
            movement.StopMovement();
            movement.enabled = false;

            currentNode = dialogue.FirstNode;
            npcName.text = dialogue.NPCName;
            audioSource.clip = dialogue.NPCVoice;

            EnableButtons();

            StartCoroutine(TypeSentence(currentNode.dialogueLine));
        }
    }

    public void DisplayNextSentence(int index)
    {
        if(isInteracting)
        {
            if (currentNode.Choices.Length == 0)
            {
                StartCoroutine(EndDialogue());
                return;
            }

            currentNode = currentNode.Choices[index].ChoiceNode;
            EnableButtons();

            StartCoroutine(TypeSentence(currentNode.dialogueLine));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
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
            currentNode = null;
            yield return new WaitForSeconds(0.5f);
            isInteracting = false;
        }
    }

    private void EnableButtons()
    {
        defaultButton.gameObject.SetActive(true);
        bOption1.gameObject.SetActive(false);
        bOption2.gameObject.SetActive(false);
        bOption3.gameObject.SetActive(false);
        
        if (currentNode.Choices.Length != 0)
        {
            defaultButton.gameObject.SetActive(false);

            bOption1.gameObject.SetActive(true);
            bOption1.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = currentNode.Choices[0].ChoicePreview;

            if (currentNode.Choices.Length > 1)
            {
                bOption2.gameObject.SetActive(true);
                bOption1.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = currentNode.Choices[1].ChoicePreview;
            }
            if (currentNode.Choices.Length > 2)
            {
                bOption3.gameObject.SetActive(true);
                bOption1.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = currentNode.Choices[2].ChoicePreview;
            }
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
