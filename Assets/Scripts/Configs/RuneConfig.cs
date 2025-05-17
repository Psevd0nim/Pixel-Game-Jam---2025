using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class RuneConfig : ScriptableObject
{
    public List<RuneData> runeDataList;

    public RuneData GetRuneDataById(int runeId)
    {
        return runeDataList[runeId];
    }
}

[Serializable]
public class RuneData
{
    [PreviewField]
    public Sprite sprite;
    public RuneType type;
}

public enum RuneType
{
    One, Two, Three, Four, Five, Six, Seven, Eight, Nine
}