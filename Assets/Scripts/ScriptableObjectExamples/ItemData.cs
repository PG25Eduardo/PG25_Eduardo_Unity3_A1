using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// abstract prevents direct usage of this class, you have to inherit from this class to use it
public abstract class ItemData : ScriptableObject
{
    [field: SerializeField, BoxGroup("Item")] public string DisplayName { get; private set; } = "New Weapon";
    [field: SerializeField, BoxGroup("Item")] public string Description { get; private set; } = "Stabs things.";
    [field: SerializeField, BoxGroup("Item")] public float Weight { get; private set; } = 1f;
    [field: SerializeField, BoxGroup("Item")] public ItemRarity Rarity { get; private set; } = ItemRarity.Common;
}

public enum ItemRarity
{
    Trash,
    Common,
    Uncommon,
    Magic,
    Rare,
    Legendary,
    Mythic
}