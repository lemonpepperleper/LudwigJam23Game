using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsAbilityState : BaseState
{
    protected MadCootsStateMachine cootsSM;
    protected CootsAbilityManager abilityManager;
    protected CootsData coots;

    protected bool abilityFinished;

    public MadCootsAbilityState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        cootsSM = (MadCootsStateMachine)stateMachine;
        abilityManager = cootsSM.abilityManager;
        coots = cootsSM.cootsData;
    }

    public override void OnEnter()
    {
        abilityFinished = false;
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnUpdate()
    {
        if (abilityFinished)
        {
            stateMachine.SwitchState(cootsSM.idleState);
        }
    }

}
