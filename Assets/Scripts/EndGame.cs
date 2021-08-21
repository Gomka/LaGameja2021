using System.Collections;
using UnityEngine;

public class EndGame : Interactable
{
    [SerializeField] private GameObject player;
    [SerializeField] Animator postproAnimator, endCreditsAnimator, arbolAnimator;
    [SerializeField] GameObject[] arbol;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    private LevelLoader levelLoader;
    private Animator animator;
    private MovementController movement;
    public Dialogue dialogue;
    private DialogueManager dManager;
    private bool endCredits = false;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        animator = player.GetComponent<Animator>();
        movement = player.GetComponent<MovementController>();
        dManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movement.StopMovement();
        movement.enabled = false;
        animator.SetTrigger("End");
        audioSource.PlayOneShot(clip);
        StartCoroutine(Llamada());
    }

    IEnumerator Llamada()
    {
        yield return new WaitForSeconds(2);
        dManager.StartDialogue(dialogue);
    }

    public void FinLlamada()
    {
        movement.enabled = false;
        animator.SetTrigger("Pastillas");
        StartCoroutine(Pastillas());
    }

    IEnumerator Pastillas()
    {

        yield return new WaitForSeconds(2);
        postproAnimator.SetTrigger("Normal");
        arbolAnimator.SetTrigger("Transform");
        player.layer = 0;
        endCreditsAnimator.SetTrigger("End");
        StartCoroutine(WaitForEndCreditsEnd());
    }

    IEnumerator WaitForEndCreditsEnd()
    {
        endCredits = true;
        yield return new WaitForSeconds(10);
        ExitToMenu();
    }

    public override void Interact()
    {

    }

    public override void Exit()
    {
        if (endCredits) ExitToMenu();
    }

    public void ExitToMenu()
    {
        levelLoader.LoadLevel("MainMenu");
    }
}
