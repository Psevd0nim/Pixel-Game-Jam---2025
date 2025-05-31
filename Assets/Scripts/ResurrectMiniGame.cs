using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResurrectMiniGame : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public bool canSetActive;

    [SerializeField] private ResMiniGameUI _resMiniGameUI;
    [SerializeField] private RunesBag _runesBag;

    private Rune _currentActiveRune;
    private bool _moveRuneActive;

    public void SetActive()
    {
        transform.position = (Vector2)Camera.main.transform.position;
        gameObject.SetActive(true);
        _resMiniGameUI.gameObject.SetActive(true);
        canSetActive = false;
    }

    private void Update()
    {
        if(_runesBag.runesForLine.Count > 0)
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
        for (int i = 0; i < _runesBag.runesForLine.Count; i++)
        {
            lineRenderer.SetPosition(i, _runesBag.runesForLine[i].transform.position);
        }
        lineRenderer.SetPosition(_runesBag.runesForLine.Count, _runesBag.runesForLine[0].transform.position);
    }
}
