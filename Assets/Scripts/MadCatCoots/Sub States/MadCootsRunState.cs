using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsRunState : MadCootsMovementState
{
    public MadCootsRunState(StateMachine stateMachine) : base("Run", stateMachine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        cootsSM.animator.Play("Walk");
    }

    public override void OnExit()
    {
    }
      
    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        Vector2 target = cootsSM.player.position;
        Vector2 newPos = Vector2.MoveTowards(cootsSM.body.position, target, cootsSM.cootsData.moveSpeed * Time.fixedDeltaTime);
        cootsSM.body.MovePosition(newPos);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (distance <= cootsSM.cootsData.runRange && cootsSM.player.position.x == cootsSM.body.position.x)
        {
            stateMachine.SwitchState(cootsSM.idleState);
        }
    }
}
