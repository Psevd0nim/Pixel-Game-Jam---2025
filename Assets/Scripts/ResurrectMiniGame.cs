using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResurrectMiniGame : MonoBehaviour
{
    public List<Rune> runes;
    public LineRenderer lineRenderer;

    private Rune _currentActiveRune;
    private bool _moveRuneActive;

    private void Start()
    {
        lineRenderer.positionCount = runes.Count + 1;
    }

    private void Update()
    {
        SetPosesForRunes();

        if(_moveRuneActive)
            MoveRune();
    }

    public void StartInput(Rune rune)
    {
        _currentActiveRune = rune;
        _moveRuneActive = true;
    }

    public void EndInput()
    {
        _currentActiveRune = null;
        _moveRuneActive = false;
    }

    private void MoveRune()
    {
        _currentActiveRune.transform.position = InputController.MousePos;
    }

    private void SetPosesForRunes()
    {
        for (int i = 0; i < runes.Count; i++)
        {
            lineRenderer.SetPosition(i, runes[i].transform.position);
        }
        lineRenderer.SetPosition(runes.Count, runes[0].transform.position);
    }
}
