using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class EndGame : Interactable
{
    [SerializeField] private GameObject player;
    private LevelLoader levelLoader;
    private Animator animator;
    [SerializeField] Animator postproAnimator, endCreditsAnimator;
    private MovementController movement;
    public Dialogue dialogue;
    private DialogueManager dManager;
    [SerializeField] GameObject[] arbol;
    private bool endCredits = false;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] VisualEffect particulas;

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
        particulas.Play();
        postproAnimator.SetTrigger("Normal");
        foreach(GameObject go in arbol)
        {
            go.SetActive(true);
        }
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
