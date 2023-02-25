using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsPhDTransitionState : BaseState
{
    protected CootsPhDStateMachine cootsSM;

    public CootsPhDTransitionState(StateMachine stateMachine) : base("Transition", stateMachine)
    {
        cootsSM = (CootsPhDStateMachine)stateMachine;
    }

    public override void OnEnter()
    {
        cootsSM.animator.Play("Transition");
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
            cootsSM.global.TurnOffCootsCam();
            cootsSM.global.MadCatTransition();
            //stateMachine.SwitchState(cootsSM.rageState);
        }
    }

}
