using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing item", menuName = "ScriptableObjects/Healing Item")]
public class HealingItemSO : ItemSO
{
    private ItemType _itemType = ItemType.Healing; //redundant
}
