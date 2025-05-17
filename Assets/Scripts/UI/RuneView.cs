using UnityEngine;
using UnityEngine.UI;

public class RuneView : MonoBehaviour
{
    public RuneType RuneType { get; private set; }

    [SerializeField] private Image _viewImage;

    private RuneData _runeData;

    public void Init(RuneData runeData)
    {
        _runeData = runeData;
        RuneType = _runeData.type;
        _viewImage.sprite = _runeData.sprite;
    }
}
