using System;
using UnityEngine;
using UnityEngine.UI;

public class RuneView : MonoBehaviour
{
    public event Action<RuneData> OnPress;

    public RuneType RuneType { get; private set; }

    [SerializeField] private Image _viewImage;

    private RuneData _runeData;

    public void Init(RuneData runeData)
    {
        _runeData = runeData;
        RuneType = _runeData.type;
        _viewImage.sprite = _runeData.sprite;
    }

    public void Press()
    {
        OnPress?.Invoke(_runeData);
        gameObject.SetActive(false);
    }
}
