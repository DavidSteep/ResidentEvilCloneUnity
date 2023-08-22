using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    
    public PlayerWalkingState(PlayerStateMachine context): base(context) { }

    public override void EnterState()
    {
        Debug.Log("Entered Walking state");
    }

    public override void UpdateState()
    {
        CheckStateSwitch();

        var movement = _context.driveInput * _context.walkSpeed * Time.deltaTime;
        _context.transform.Translate(0,0, movement);
        var rotation = _context.rotationInput * _context.rotationSpeed * Time.deltaTime;
        _context.transform.Rotate(0, rotation, 0);

    }

    protected override void CheckStateSwitch()
    {
        if(_context.isRunning && _context.driveInput > 0)
        {
            SwitchState(_context.runState);
            return;
        }

        if (_context.driveInput < 0)
        {
            SwitchState(_context.backingState);
            return;
        }

        if (_context.driveInput == 0 && _context.rotationInput == 0)
        {
            SwitchState(_context.idleState);
            return;
        }
    }

   

}
