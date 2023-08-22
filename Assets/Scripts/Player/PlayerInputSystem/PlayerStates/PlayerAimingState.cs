using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Check how resident evil handle aiming state, does it allow to enter aim state in the middle of walking?
public class PlayerAimingState : PlayerBaseState
{
    public PlayerAimingState(PlayerStateMachine context) : base(context){}

    public override void EnterState()
    {
        Debug.Log("Entered Aiming state");
    }

    public override void UpdateState() 
    {
        CheckStateSwitch();
        
        if(_context.isShooting) { 
        
        }

        var rotation = _context.rotationInput * _context.rotationSpeed * Time.deltaTime;
        _context.transform.Rotate(0, rotation, 0);


    }

    protected override void CheckStateSwitch()
    {
        if(!_context.isAiming) { SwitchState(_context.idleState); return; }
    }
}
