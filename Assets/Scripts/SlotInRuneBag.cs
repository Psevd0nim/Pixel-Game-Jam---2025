using Sirenix.OdinInspector;
using UnityEngine;

public class SlotInRuneBag : MonoBehaviour
{
    [ShowInInspector]
    public RuneView RuneView { get; private set; }

    public void SetRuneView(RuneView runeView)
    {
        RuneView = runeView;
        RuneView.transform.position = transform.position;
    }
}
