using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputHandler input;
    private Vector2 movementDirection;
    public Rigidbody2D rb;
    public float movementSpeed = 5f;
    public Animator ar;

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
        rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
    }
    private void OnEnable()
    {
        input.PlayerMovementEvent += DirectionWalk;
    }

    private void OnDisable()
    {
        input.PlayerMovementEvent -= DirectionWalk;
    }

    public void DirectionWalk(Vector2 direction)
    {
        movementDirection = direction;
    }
    



}
