using UnityEngine;

public class DissolveOnProximity : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") animator.SetBool("Appear", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") animator.SetBool("Appear", false);
    }
}
