using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsCrashState : MadCootsAbilityState
{

    private Vector2 targetUp = new Vector2(8f, 25f);
    private Vector2 targetDown = new Vector2(8f, -5f);
    private bool reachedUp = false;
    private bool reachedDown = false;
    protected BoxCollider2D collider2D;
    public MadCootsCrashState(StateMachine stateMachine) : base("Crash", stateMachine)
    {
        collider2D = cootsSM.GetComponent<BoxCollider2D>();
    }

    public override void OnEnter()
    {
        cootsSM.animator.Play("InFlight");
        collider2D.enabled = false;
        cootsSM.body.velocity = Vector2.zero;
        cootsSM.enraged = true;
    }

    public override void OnExit()
    {
        collider2D.enabled = true;

    }

    public override void OnFixedUpdate()
    {
        if (!reachedUp)
        {
            Vector2 newPos = Vector2.MoveTowards(cootsSM.body.position, targetUp, coots.leapSpeed * Time.fixedDeltaTime);
            cootsSM.body.MovePosition(newPos);
        } else if (!reachedDown)
        {
            Vector2 newPos = Vector2.MoveTowards(cootsSM.body.position, targetDown, coots.leapSpeed * Time.fixedDeltaTime);
            cootsSM.body.MovePosition(newPos);
        }

    }

    public override void OnUpdate()
    {

        if (cootsSM.body.position == targetUp)
        {
            reachedUp = true;
        }
        if (reachedUp && cootsSM.body.position == targetDown)
        {
            reachedDown = true;
        }
        if (reachedDown)
        {
            stateMachine.SwitchState(cootsSM.landedState);
        }
    }
}
