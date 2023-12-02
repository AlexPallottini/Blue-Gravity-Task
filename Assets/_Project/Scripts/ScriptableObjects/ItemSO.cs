using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item/NewItemData", fileName ="NewItem")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public ItemType type;
    [field: SerializeField] public int Value;
    [field: SerializeField] public Sprite sprite;
}

[Serializable]
public enum ItemType
{
    None = 0,
    Hood = 1,
    Face = 2,
    Torso = 3
}
