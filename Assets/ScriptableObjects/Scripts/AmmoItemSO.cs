using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ammo item", menuName = "ScriptableObjects/Ammo Item")]
public class AmmoItemSO : ItemSO
{
    //[SerializeField]
    //private int _amount; //Should ammount be here? No, makes more sense int the ItemGameObject instance and the container of Inventory system

    [SerializeField]
    private AmmoTypeSO _ammoType;
    [SerializeField] 
    public AmmoTypeSO GetAmmoType()
    {
        return _ammoType;
    }


}
