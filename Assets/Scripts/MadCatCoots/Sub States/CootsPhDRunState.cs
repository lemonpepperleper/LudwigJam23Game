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
        if (x >= cootsSM.body.position.x)
        {
            cootsSM.transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            cootsSM.transform.localScale = new Vector3(1, 1, 1);
        }
        
        Vector2 newPos = Vector2.MoveTowards(cootsSM.body.position, target, cootsSM.cootsData.sprintSpeed * Time.fixedDeltaTime);
        cootsSM.body.MovePosition(newPos);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        target = new Vector2(x, y);

        if (cootsSM.body.position == target)
        {
            stateMachine.SwitchState(cootsSM.throwState);
        }
    }
}
