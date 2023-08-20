using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerGun
{
    public void shoot();
    public bool reload(AmmoTypeSO ammoType, int ammoAmount, out int amountUsed);
  
}
