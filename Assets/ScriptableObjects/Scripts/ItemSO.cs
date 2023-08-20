using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Have this enum be a scriptable object instead?
public enum ItemType
{
    Ammo,
    Healing,
    Weapons,
    Key
}
public abstract class ItemSO : ScriptableObject
{
    private ItemType _itemType; //Redundant? Make into a SO?
    [SerializeField]
    private string _itemName;
    [SerializeField]
    private Sprite _menuItemSprite;

    //[SerializeField]
    //private int _amount;

    [SerializeField]
    private bool _isStackable;

    public ItemType GetItemType() { return _itemType; }
    public bool CanBeStacked() { return _isStackable; }

    //public bool AddToStack(int amount) { 

    //    if(_isStackable) { _amount += amount; return true; } 
    //    else { return false; }
    
    //}

    //public bool RemoveFromStack(int amount)
    //{
    //    if (_isStackable) { _amount -= amount; return true; }
    //    else { return false; }
    //}

}
