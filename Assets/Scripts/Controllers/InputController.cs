using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static Vector2 MousePos { get; private set; }

    private RaycastHit2D[] hits;

    private ResurrectMiniGame _resurrectMiniGame;
    private Player _player;
    private InputSystem_Actions inputActions;

    private void Update()
    {
        CheckInput();
    }

    public void Init(ResurrectMiniGame resurrectMiniGame, Player player)
    {
        _resurrectMiniGame = resurrectMiniGame;
        inputActions = new InputSystem_Actions();
        _player = player;
        PlayerSetInput();
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
        PlayerClearInput();
    }

    public void PlayerSetInput()
    {
        inputActions.Player.Move.performed += PlayerInput;
        inputActions.Player.Move.canceled += PlayerInput;
    }

    private void PlayerClearInput()
    {
        inputActions.Player.Move.performed -= PlayerInput;
        inputActions.Player.Move.canceled -= PlayerInput;
    }

    private void PlayerInput(InputAction.CallbackContext context)
    {
        _player.direction = context.ReadValue<Vector2>();
    }

    private void CheckInput()
    {
        if (Mouse.current == null) return;

        MousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        hits = Physics2D.RaycastAll(MousePos, Vector2.zero);

        CheckForClickDownLogic();

        CheckForClickUpLogic();

        CheckForKeaybordInput();
    }

    private void CheckForKeaybordInput()
    {
        if(Keyboard.current == null) return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (_resurrectMiniGame.canSetActive)
            {
                _resurrectMiniGame.SetActive();
                PlayerClearInput();
            }
        }
    }

    private void CheckForClickDownLogic()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            foreach(var hit in hits)
            {
                if (hit.collider.GetComponent<Rune>())
                {
                    _resurrectMiniGame.StartInput(hit.collider.GetComponent<Rune>());
                }
            }
        }
    }

    private void CheckForClickUpLogic()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
            _resurrectMiniGame.EndInput();
    }
}