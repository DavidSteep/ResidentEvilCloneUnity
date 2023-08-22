using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public PlayerRunningState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        Debug.Log("Entered Running state");
    }

    public override void UpdateState()
    {
        CheckStateSwitch();
        var movement = _context.driveInput * _context.runSpeed * Time.deltaTime;
        _context.transform.Translate(0, 0, movement);
        var rotation = _context.rotationInput * _context.rotationSpeed * Time.deltaTime;
        _context.transform.Rotate(0, rotation, 0);
    }

    protected override void CheckStateSwitch()
    {
        if(!_context.isRunning)
        {
            SwitchState(_context.walkState);
        }
    }

    
}
