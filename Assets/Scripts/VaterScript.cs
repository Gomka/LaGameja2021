using System.Collections;
using UnityEngine;

public class VaterScript : Interactable
{
    [SerializeField] private GameObject player;
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
