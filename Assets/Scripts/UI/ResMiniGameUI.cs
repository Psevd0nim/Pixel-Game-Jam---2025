using System.Collections.Generic;
using UnityEngine;

public class ResMiniGameUI : MonoBehaviour
{
    [SerializeField] private RunesBag _runesBag;

    private void Start()
    {
        _runesBag.FillRunesBagUI();
    }
}
