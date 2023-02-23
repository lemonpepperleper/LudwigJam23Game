using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsIdleState : MadCootsMovementState
{
    public MadCootsIdleState(StateMachine stateMachine) : base("Idle", stateMachine)
    {

    }

    public override void OnEnter()
    {
        cootsSM.animator.Play("Idle");
        cootsSM.body.velocity = Vector2.zero;
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (distance > cootsSM.cootsData.runRange)
        {
            stateMachine.SwitchState(cootsSM.runState);
        }
    }

}
