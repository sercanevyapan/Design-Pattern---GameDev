using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface LocomotionContext
{
    void SetState(LocomotionsState newState);
}

public interface LocomotionsState
{
    void Jump(LocomotionContext context);
    void Fall(LocomotionContext context);
    void Land(LocomotionContext context);
    void Crouch(LocomotionContext context);
}

public class LocomotionStatePattern : MonoBehaviour, LocomotionContext
{

    LocomotionsState currentState = new GroundedState();

    public void Crouch() => currentState.Crouch(this);
    public void Fall() => currentState.Fall(this);
    public void Jump() => currentState.Jump(this);
    public void Land() => currentState.Land(this);

    void LocomotionContext.SetState(LocomotionsState newState){
        currentState = newState;
    }
}

public class GroundedState : LocomotionsState
{
    public void Crouch(LocomotionContext context)
    {
        context.SetState(new CrouchingState());
    }

    public void Fall(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Jump(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Land(LocomotionContext context)
    {
        
    }
}

public class InAirState : LocomotionsState
{
    public void Crouch(LocomotionContext context)
    {
        
    }

    public void Fall(LocomotionContext context)
    {
        
    }

    public void Jump(LocomotionContext context)
    {
       
    }

    public void Land(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
}

public class CrouchingState : LocomotionsState
{
    public void Crouch(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }

    public void Fall(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Jump(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }

    public void Land(LocomotionContext context)
    {
       
    }
}
