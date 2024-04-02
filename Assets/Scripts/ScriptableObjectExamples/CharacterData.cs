using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// to create ScriptableObject (SO) we inherit From ScriptableObject
// and add a createassetmenu to show the asset in our menus
[CreateAssetMenu(fileName = "New Character Data", menuName = "Data/New Character")]
public class CharacterData : ScriptableObject
{
    [field: SerializeField, BoxGroup("Character")] public string DisplayName { get; private set; } = "Character Name";
    [field: SerializeField, BoxGroup("Character")] public CharacterClass Class { get; private set; } = CharacterClass.Fool;
    [field: SerializeField, BoxGroup("Character")] public CharacterAlignment Alignment { get; private set; } = CharacterAlignment.TrueNeutral;
    [field: SerializeField, BoxGroup("Character"), TextArea] public string BackStory { get; private set; } = "Probably dead parents.";

    [field: SerializeField, BoxGroup("Stats")] public int Level { get; private set; } = 1;
    [field: SerializeField, BoxGroup("Stats"), PropertyRange(1, 20)] public int Health { get; private set; } = 10;
    [field: SerializeField, BoxGroup("Stats"), PropertyRange(1, 20)] public int Speed { get; private set; } = 10;
    [field: SerializeField, BoxGroup("Stats"), PropertyRange(1, 20)] public int Damage { get; private set; } = 10;
    [field: SerializeField, BoxGroup("Stats"), PropertyRange(1, 20)] public int Magic { get; private set; } = 10;
    [field: SerializeField, BoxGroup("Stats"), PropertyRange(1, 20)] public int ShoeSize { get; private set; } = 10;
    [field: SerializeField, BoxGroup("Stats"), PropertyRange(1, 20)] public int EnergyProjection { get; private set; } = 10;
    [field: SerializeField, BoxGroup("Stats"), PropertyRange(1, 20)] public int Popularity { get; private set; } = 10;
    [field: SerializeField, BoxGroup("Stats"), PropertyRange(0, 4)] public int WisdomToothCount { get; private set; } = 4;

    [field: SerializeField, BoxGroup("Inventory")] public WeaponData EquippedWeapon { get; private set; }
    [field: SerializeField, BoxGroup("Inventory")] public List<ItemData> BackpackContents { get; private set; }

}

public enum CharacterClass
{
    Bard,
    StreetRat,
    Thief,
    Chef,
    Wizard,
    Fool,
    Noble
}

public enum CharacterAlignment
{
    LawfulGood,
    NeutralGood,
    ChaoticGood,
    LawfulNeutral,
    TrueNeutral,
    ChaoticNeutral,
    LawfulEvil,
    NeutralEvil,
    ChaoticEvil
}