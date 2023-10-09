using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class InvItemData : ScriptableObject
{
    public Sprite itemIcon;
    public int itemStackablility;
    public int itemID;
    public string itemDisplayedName;
    [TextArea(4,4)]
    public string itemDisplayedDesc;
}
