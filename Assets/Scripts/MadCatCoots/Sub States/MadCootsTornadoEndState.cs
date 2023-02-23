using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsTornadoEndState : MadCootsAbilityState
{

    public MadCootsTornadoEndState(StateMachine stateMachine) : base("TornadoEnd", stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        cootsSM.animator.Play("TornadoEnd");
        cootsSM.body.velocity = Vector2.zero;
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (cootsSM.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            abilityFinished = true;
        }
    }
}
