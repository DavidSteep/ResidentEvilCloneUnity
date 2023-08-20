using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//Move to a player script instead, uneccesarry here i feel like.
public class PlayerInventorySystem : MonoBehaviour
{ 
    [SerializeField]
    private InventorySO _inventory;
    [SerializeField]
    private List<GameObject> _itemsInPickUpRange;

    
    private void Awake()
    {
        if (_inventory == null)
            _inventory = new InventorySO();
    }

    //TODO: Move input logic to controller
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_itemsInPickUpRange.Count > 0)
            {
                pickUpItem(); 
            }

        }
    }

    public void pickUpItem()
    {
        //TODO, redo this code so that it just takes the one that's closest to.
        var itemGameObject = _itemsInPickUpRange.First().GetComponent<Item>();
        if (itemGameObject == null)
            return;

        var itemInfo = itemGameObject.CheckItem(); 

        if (_inventory.addItem(itemInfo.itemType, itemInfo.amount))
        {
            _itemsInPickUpRange.Remove(itemGameObject.gameObject);
            itemGameObject.ObtainItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Item>())
        {
            Debug.Log("Entered item: " + other.gameObject.name);
            _itemsInPickUpRange.Add(other.gameObject);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            Debug.Log("Exited item: " + other.gameObject.name);
            _itemsInPickUpRange.Remove(other.gameObject);
        }
            
    }

}
