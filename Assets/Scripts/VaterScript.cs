using System.Collections;
using UnityEngine;

public class VaterScript : Interactable
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;
    private LevelLoader levelLoader;
    private Animator animator;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (inside)
        {
            player.SetActive(false);
            animator.SetTrigger("Start");
            source.PlayOneShot(clip);
            StartCoroutine(PlayToiletAnim());
        }
    }

    public override void Exit()
    {

    }

    IEnumerator PlayToiletAnim()
    {
        yield return new WaitForSeconds(0.5f);
        levelLoader.LoadLevel("SR_Vater1");
    }
}
