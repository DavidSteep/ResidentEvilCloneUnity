using UnityEngine;

public class PlayerBackingState : PlayerBaseState
{
   public PlayerBackingState(PlayerStateMachine context) : base(context)
    {

    }

    public override void EnterState()
    {
        Debug.Log("Entered Backing state");
    }

    public override void UpdateState()
    {
        CheckStateSwitch();
        var movement = _context.driveInput * _context.backwardsWalkSpeed * Time.deltaTime;
        _context.transform.Translate(0, 0, movement);
        var rotation = _context.rotationInput * _context.rotationSpeed * Time.deltaTime;
        _context.transform.Rotate(0, rotation, 0);
    }

    protected override void CheckStateSwitch()
    {
        if (_context.isRunning && _context.driveInput > 0)
        {
            SwitchState(_context.runState);
            return;
        }

        if (_context.driveInput > 0)
        {
            SwitchState(_context.walkState);
            return;
        }

        if (_context.driveInput == 0 && _context.rotationInput == 0)
        {
            SwitchState(_context.idleState);
            return;
        }
    }
}
