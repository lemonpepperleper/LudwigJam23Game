using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsDeathState : MadCootsAbilityState
{

    public MadCootsDeathState(StateMachine stateMachine) : base("Death", stateMachine)
    {
    }

    public override void OnEnter()
    {
        cootsSM.global.deadDialogue.TriggerDialogue();
        abilityManager.faded = false;
        cootsSM.animator.Play("Stunned");
        cootsSM.body.velocity = Vector2.zero;
        abilityManager.StartCoroutine(abilityManager.FadeAway());
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {

        if (abilityManager.faded)
        {
            WinScreenManager.instance.ShowWinScreen();
        }
    }
}
