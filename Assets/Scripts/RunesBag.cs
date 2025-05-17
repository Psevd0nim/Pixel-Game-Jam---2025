using System.Collections.Generic;
using UnityEngine;

public class RunesBag : MonoBehaviour
{
    [SerializeField] private RuneConfig _config;
    [SerializeField] private RuneView _runeViewPrefab;
    [SerializeField] private List<SlotInRuneBag> slotList;

    public void FillRunesBag()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            SlotInRuneBag slot = slotList[i];
            RuneView runeView = Instantiate(_runeViewPrefab, slot.gameObject.transform);
            runeView.Init(_config.GetRuneDataById(i));
            slotList[i].SetRuneView(runeView);
        }
    }
}