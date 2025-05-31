using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RunesBag : MonoBehaviour
{
    [ReadOnly] public List<Rune> allRunes;
    [ReadOnly] public List<Rune> runesForLine;

    [SerializeField] private RuneConfig _config;
    [SerializeField] private RuneView _runeViewPrefab;
    [SerializeField] private List<SlotInRuneBag> slotList;

    public void FillRunesBagUI()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            SlotInRuneBag slot = slotList[i];
            RuneView runeView = Instantiate(_runeViewPrefab, slot.gameObject.transform);
            runeView.Init(_config.GetRuneDataById(i));
            slotList[i].SetRuneView(runeView);

            runeView.OnPress += CreateRune;
        }
    }

    private void CreateRune(RuneData runeData)
    {

    }
}