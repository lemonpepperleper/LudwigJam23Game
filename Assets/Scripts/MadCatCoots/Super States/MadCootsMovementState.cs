using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsMovementState : BaseState
{
    protected MadCootsStateMachine cootsSM;
    protected CootsAbilityManager abilityManager;
    protected CootsData coots;

    protected float distance;
    
    
    public MadCootsMovementState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        cootsSM = (MadCootsStateMachine)stateMachine;
        abilityManager = cootsSM.abilityManager;
        coots = cootsSM.cootsData;
    }

    public override void OnEnter()
    {
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
        distance = Vector2.Distance(cootsSM.player.position, cootsSM.body.position);

        if (cootsSM.hurtBox.currentHP <= 0f)
        {
            stateMachine.SwitchState(cootsSM.deathState);
        }

        else if ((cootsSM.hurtBox.currentHP <= 100f && !cootsSM.enraged) || (cootsSM.enraged && abilityManager.isCrashOffCd))
        {
            stateMachine.SwitchState(cootsSM.leapChargeState);
        }

        else if (!abilityManager.isLocked)
        {
            if (abilityManager.isTornadoOffCd)
            {
                stateMachine.SwitchState(cootsSM.tornadoStartState);
            }

            else if (abilityManager.isStompOffCd)
            {
                stateMachine.SwitchState(cootsSM.stompState);
            }

            else if (abilityManager.isRoarOffCd && distance <= coots.roarTriggerRange)
            {
                stateMachine.SwitchState(cootsSM.roarState);
            }

            else if (abilityManager.isPunchOffCd)
            {
                stateMachine.SwitchState(cootsSM.punchState);
            }

            else if (abilityManager.isSwipeOffCd && distance <= coots.swipeTriggerRange)
            {
                stateMachine.SwitchState(cootsSM.swipeState);
            }
        }

    }

}
