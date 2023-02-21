using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerMovementState
{

    public PlayerIdleState(PlayerStateMachine stateMachine) : base("Idle", stateMachine)
    {

    }

    public override void OnEnter()
    {
        playerSM.animator.Play("Idle");
        playerSM.body.velocity = Vector2.zero;
    }


    public override void OnUpdate()
    {
        base.OnUpdate();

        if (direction.sqrMagnitude > 0)
        {
            stateMachine.SwitchState(playerSM.runState);
        }
    }


    public override void OnFixedUpdate()
    {

    }


    public override void OnExit()
    {
        base.OnExit();
    }
}
