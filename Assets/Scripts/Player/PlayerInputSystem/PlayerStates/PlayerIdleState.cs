using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine context) : base(context) { }

    public override void EnterState()
    {
        Debug.Log("Enetered Idle mode");
    }

    public override void UpdateState()
    {
        CheckStateSwitch();
    }

    protected override void CheckStateSwitch()
    {


        if (_context.isAiming)
        {
            SwitchState(_context.aimState);
            return;
        }

        if (_context.driveInput > 0 && _context.isRunning)
        {

            SwitchState(_context.walkState);
            return;
        }

        if (_context.driveInput < 0)
        {

            SwitchState(_context.backingState);
            return;
        }

        if (_context.driveInput > 0 || _context.rotationInput != 0)
        {

            SwitchState(_context.walkState);
            return;
        }
    }
}
