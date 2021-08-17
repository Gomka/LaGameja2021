using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public InputMaster input;

    public delegate void PlayerMovementDelegate(Vector2 direction);
    public event PlayerMovementDelegate PlayerMovementEvent;
    public delegate void PlayerInteractionDelegate();
    public event PlayerInteractionDelegate PlayerInteractionEvent;
    public delegate void PauseDelegate();
    public event PauseDelegate PauseEvent;
    public delegate void SprintDelegate(bool isPressed);
    public event SprintDelegate SprintEvent;
    public delegate void MenuMovementDelegate(Vector2 direction);
    public event MenuMovementDelegate MenuMovementEvent;
    public delegate void MenuInteractionDelegate();
    public event MenuInteractionDelegate MenuInteractionEvent;
    public delegate void ExitDelegate();
    public event ExitDelegate ExitEvent;

    private void Awake()
    {
        input = new InputMaster();

        input.Player.Movement.performed += ctx => PlayerMovement(ctx.ReadValue<Vector2>());
        input.Player.Interaction.performed += ctx => PlayerInteraction();
        input.Player.Pause.performed += ctx => Pause();
        input.Player.Sprint.performed += ctx => Sprint(ctx.ReadValue<float>());

        input.Menu.Movement.performed += ctx => MenuMovement(ctx.ReadValue<Vector2>());
        input.Menu.Interaction.performed += ctx => MenuInteraction();
        input.Menu.Exit.performed += ctx => Exit();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void PlayerMovement(Vector2 direction)
    {
        if (PlayerMovementEvent != null) PlayerMovementEvent(direction);
    }

    void PlayerInteraction()
    {
        if (PlayerInteractionEvent != null) PlayerInteractionEvent();
    }

    void Pause()
    {
        if (PauseEvent != null) PauseEvent();
    }

    void Sprint(float val)
    {
        if (SprintEvent != null) SprintEvent(val > 0.5);
    }

    void MenuMovement(Vector2 direction)
    {
        if (MenuMovementEvent != null) MenuMovementEvent(direction);
    }

    void MenuInteraction()
    {
        if (MenuInteractionEvent != null) MenuInteractionEvent();
    }
    void Exit()
    {
        if (ExitEvent != null) ExitEvent();
    }
}
