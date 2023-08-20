using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunInfoSO : ScriptableObject
{
    public int loadedAmmo;
    public int ammoCapacity;
    public AmmoTypeSO loadedAmmoType;
    public List<AmmoTypeSO> acceptedAmmoTypes;
    public float baseDamage;


}
