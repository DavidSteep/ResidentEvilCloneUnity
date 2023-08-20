using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{

    private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

    [SerializeField]
    private int _maxInventorySlots;

    public bool addItem(ItemSO item, int amount)
    {

        if(item.CanBeStacked())
        {
            var slot = _inventorySlots.Where(slot => slot.item == item).First();

            if(slot != null)
            {
                slot.amount += amount;
                return true;
            }
        }

        if(_inventorySlots.Count < _maxInventorySlots)
        {
            _inventorySlots.Add(new InventorySlot(item, amount));
            return true;
        }
        else
        {
            return false;
        }
    }

}

[System.Serializable]
public class InventorySlot
{

    //Maybe protect these with property getters and setters, but this won't be used anywhere else so who cares.
    public ItemSO item;
    public int amount;

    public InventorySlot(ItemSO item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    
}