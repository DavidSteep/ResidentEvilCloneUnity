using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//TODO: Maybe can be scriptableObject? (How to solve transform then? As parameters to the shoot function of corse!)
public class PlayerHandgun : MonoBehaviour, IPlayerGun
{
    [SerializeField]
    private GunInfoSO gunStats; //Maybe don't have to have this SO if the entire gun class is an SO?

    public UnityEvent<AmmoTypeSO, List<AmmoTypeSO>> gunOutOfAmmoEvent; //Should you be able to autoreload to a new ammotype?


    public void Awake()
    {
        if(gunOutOfAmmoEvent != null)
        {
            gunOutOfAmmoEvent = new UnityEvent<AmmoTypeSO, List<AmmoTypeSO>>();
        }
    }

    //TODO: Make shoot logic be a scriptableObject too.
    public void shoot() //Should it have a out parameter that says how many bullets where used?
    {
        if (gunStats.loadedAmmo <= 0)
        {
            gunOutOfAmmoEvent.Invoke(gunStats.loadedAmmoType, gunStats.acceptedAmmoTypes);
            return;
        }

        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;
        Ray ray = new Ray(rayOrigin, rayDirection);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50f))
        {
            IEnemyBehaviour target = hit.transform.GetComponent<IEnemyBehaviour>();
            if (target != null)
            {
                Debug.Log(hit.transform.name);
                Debug.Log(hit.distance);
                target.TakeDamage(gunStats.baseDamage); //Coupled?
            }
        }

        Debug.DrawRay(transform.position, rayDirection * 50f, Color.white, 50f);
    }


    public bool reload(AmmoTypeSO ammoType, int ammoAmount, out int amountUsed)
    {
        if (!gunStats.acceptedAmmoTypes.Contains(ammoType))
        {
            amountUsed = 0;
            return false;
        }

        //Just incase if we somehow load zero ammo
        if(ammoAmount != 0)
        {
            gunStats.loadedAmmoType = ammoType; // Have a type of "IProperyChangedtEvent" on loadedAmmoType so that the inventory UI is updated.
        }

        var ammoSpaceLeft = gunStats.ammoCapacity - gunStats.loadedAmmo;

        if (ammoAmount > ammoSpaceLeft)
        {
            gunStats.loadedAmmo = gunStats.ammoCapacity;
            amountUsed = ammoSpaceLeft;
        }
        else
        {
            gunStats.ammoCapacity += ammoAmount;
            amountUsed = ammoAmount;
        }
        return true;

    }
}
