using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsStompState : MadCootsAbilityState
{


    public MadCootsStompState(StateMachine stateMachine) : base("Stomp", stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        cootsSM.animator.Play("Stomp");
        cootsSM.body.velocity = Vector2.zero;

        abilityManager.isStompOffCd = false;

        abilityManager.StartCoroutine(abilityManager.StompCoolDown());
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

        if (cootsSM.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 3f)
        {
            abilityFinished = true;
        }
    }
}
