using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastillesCommand : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    [SerializeField] private InputHandler input;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        input.PlayerInteractionEvent += PastillesInteraction;
    }

    private void OnDisable()
    {

        input.PlayerInteractionEvent -= PastillesInteraction;
    }

    public void PastillesInteraction()
    {
        animator.SetTrigger("Interaction");
    }


}
