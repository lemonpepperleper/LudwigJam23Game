using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsDashChargeState : MadCootsAbilityState
{


    public MadCootsDashChargeState(StateMachine stateMachine) : base("DashCharge", stateMachine)
    {
    }

    public override void OnEnter()
    {

        cootsSM.animator.Play("Charge");
        cootsSM.body.velocity = Vector2.zero;
        abilityManager.isDashChargeDone = false;
        abilityManager.StartCoroutine(abilityManager.DashChargeDone());
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
        cootsSM.FacePlayer(cootsSM.player);
    }

    public override void OnUpdate()
    {

        if (abilityManager.isDashChargeDone)
        {
            stateMachine.SwitchState(cootsSM.chargeState);
        }
    }
}
