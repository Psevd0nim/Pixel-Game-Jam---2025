using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private ResurrectMiniGame _resurrectMiniGame;
    [SerializeField] private Player _player;

    private void Awake()
    {
        StartInits();
    }

    private void StartInits()
    {
        _inputController.Init(_resurrectMiniGame, _player);
    }
}
