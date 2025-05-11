using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static Vector2 MousePos { get; private set; }

    private RaycastHit2D[] hits;

    private ResurrectMiniGame _resurrectMiniGame;

    private void Update()
    {
        CheckInput();
    }

    public void Init(ResurrectMiniGame resurrectMiniGame)
    {
        _resurrectMiniGame = resurrectMiniGame;
    }

    private void CheckInput()
    {
        if (Mouse.current == null) return;

        MousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        hits = Physics2D.RaycastAll(MousePos, Vector2.zero);

        CheckForClickDownLogic();

        CheckForClickUpLogic();
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