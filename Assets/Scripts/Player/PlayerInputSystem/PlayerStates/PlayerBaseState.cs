
using UnityEngine;
public abstract class PlayerBaseState
{
    protected PlayerStateMachine _context;

    public PlayerBaseState(PlayerStateMachine context)
    {
        _context = context;
    }

    public abstract void EnterState();
    public abstract void UpdateState();

    public void SwitchState(PlayerBaseState newState) {
        _context.UpdateState(newState);
    }

    protected abstract void CheckStateSwitch();
}