using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsTornadoStartState : MadCootsAbilityState
{

    public MadCootsTornadoStartState(StateMachine stateMachine) : base("TornadoStart", stateMachine)
    {
    }

    public override void OnEnter()
    {

        cootsSM.animator.Play("TornadoStart");
        abilityManager.isTornadoOffCd = false;
        abilityManager.StartCoroutine(abilityManager.TornadoCoolDown());
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
        if (cootsSM.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            stateMachine.SwitchState(cootsSM.tornadoState);
        }
    }
}
