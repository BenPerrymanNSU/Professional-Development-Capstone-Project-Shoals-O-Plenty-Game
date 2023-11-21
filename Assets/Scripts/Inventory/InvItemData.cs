using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class InvItemData : ScriptableObject
{
    public Sprite itemIcon;
    public int itemStackablility;
    public int itemID;
    public string itemDisplayedName;
    [TextArea(4,4)]
    public string itemDisplayedDesc;
    public string itemType;
    public string itemDifficulty;
    public float itemGoodFishChance;
    public float itemBadFishChance;
    public float itemRequiredPercent;
    public bool itemEdibility;
    public bool itemRaw;
    public float itemHungerSatiation;
    public float itemThirstSatiation;
}
