using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsPhDRunState : CootsPhDMovementState
{
    protected Vector2 xRange = new Vector2(-9, 23);
    protected Vector2 yRange = new Vector2(-14, 2);
    protected Vector2 target;
    private float x, y;

    public CootsPhDRunState(StateMachine stateMachine) : base("Run", stateMachine)
    {

    }

    public override void OnEnter()
    {
        cootsSM.animator.Play("Run");

        x = Random.Range(xRange.x, xRange.y);
        y = Random.Range(yRange.x, yRange.y);
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        target = new Vector2(x, y);
        Vector2 newPos = Vector2.MoveTowards(cootsSM.body.position, target, cootsSM.cootsData.sprintSpeed * Time.fixedDeltaTime);
        cootsSM.body.MovePosition(newPos);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (cootsSM.body.position == target)
        {
            stateMachine.SwitchState(cootsSM.idleState);
        }
    }
}
