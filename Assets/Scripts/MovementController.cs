using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private InputHandler input;
    private Vector2 movementDirection, lastMove, lastInput;
    private Rigidbody2D rb;
    private Animator ar;
    private bool sprinting = false;
    public float movementSpeed = 5f, sprintingMultiplier = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();
    }

    void Update()
    {
        ar.SetFloat("Horizontal",lastInput.x);
        ar.SetFloat("Vertical", lastInput.y);
        ar.SetFloat("Speed", movementDirection.sqrMagnitude);
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
        input = FindObjectOfType<InputHandler>();
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
        if (direction.magnitude == 0f) // Not moving
        {
            movementDirection = direction;
            lastMove = movementDirection;
        } 
        else if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) // Only moving in x
        {
            movementDirection = new Vector2(direction.x, 0);
            lastMove = movementDirection;
            lastInput = movementDirection;
        } 
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) // Only moving in y
        {
            movementDirection = new Vector2(0, direction.y);
            lastMove = movementDirection;
            lastInput = movementDirection;
        } 
        else if (Mathf.Abs(lastMove.x) > 0) // Changing from x to y
        {
            movementDirection = new Vector2(0, direction.y);
            lastInput = movementDirection;
        } 
        else // Changing from y to x
        {
            movementDirection = new Vector2(direction.x, 0);
            lastInput = movementDirection;
        }
    }

    public void isSprinting(bool isSprinting)
    {
        sprinting = isSprinting;
        ar.SetBool("isSprinting", sprinting);
    }
}
