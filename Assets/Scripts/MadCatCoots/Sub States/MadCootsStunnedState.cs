using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsStunnedState : MadCootsAbilityState
{

    public MadCootsStunnedState(StateMachine stateMachine) : base("Stunned", stateMachine)
    {
    }

    public override void OnEnter()
    {
        cootsSM.animator.Play("Stunned");
        cootsSM.body.velocity = Vector2.zero;

        abilityManager.isStunnedDone = false;
        abilityManager.StartCoroutine(abilityManager.StunnedDone());
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {

        if (abilityManager.isStunnedDone)
        {
            stateMachine.SwitchState(cootsSM.dashChargeState);
        }
    }
}
