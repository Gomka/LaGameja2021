using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputHandler input;
    private Vector2 movementDirection;
    public Rigidbody2D rb;
    public float movementSpeed = 5f, sprintingMultiplier = 2f;
    public Animator ar;
    public bool sprinting = false;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      //ar = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        /*  ar.SetFloat("Horizontal",movementDirection.x);
            ar.SetFloat("Vertical", movementDirection.y);
            ar.SetFloat("Speed", movementDirection.sqrMagnitude);
        */  
    }

    void FixedUpdate()
    {
        if(sprinting)
        {
            rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.fixedDeltaTime * sprintingMultiplier);
        } else
        {
            rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
        } 
    }
    private void OnEnable()
    {
        input.PlayerMovementEvent += DirectionWalk;
        input.SprintEvent += isSprinting;
    }

    private void OnDisable()
    {
        input.PlayerMovementEvent -= DirectionWalk;
        input.SprintEvent -= isSprinting;
    }

    public void DirectionWalk(Vector2 direction)
    {
        movementDirection = direction;
    }

    public void isSprinting(bool isSprinting)
    {
        sprinting = isSprinting;
    }
}
