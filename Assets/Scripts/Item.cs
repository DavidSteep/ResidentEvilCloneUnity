using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemSO _itemType;
    [SerializeField]
    private int _amount;

    //Maybe replace wiht two out variables
    public (ItemSO itemType, int amount) CheckItem()
    {
        return (_itemType, _amount);
    }

    public void ObtainItem()
    {
        Destroy(gameObject);
    }

}
