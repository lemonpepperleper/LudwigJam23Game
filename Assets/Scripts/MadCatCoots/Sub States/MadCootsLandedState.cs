using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsLandedState : MadCootsAbilityState
{

    public MadCootsLandedState(StateMachine stateMachine) : base("Landed", stateMachine)
    {
    }

    public override void OnEnter()
    {
        cootsSM.animator.Play("LeapCharge");
        cootsSM.body.velocity = Vector2.zero;
        abilityManager.isleapChargeDone = false;
        abilityManager.StartCoroutine(abilityManager.LeapChargeDone());
    }

    public override void OnExit()
    {
        cootsSM.global.DropBoulders();
        abilityManager.isCrashOffCd = false;
        abilityManager.StartCoroutine(abilityManager.CrashCoolDown());
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {

        if (abilityManager.isleapChargeDone)
        {
            stateMachine.SwitchState(cootsSM.dashChargeState);
        }
    }
}
