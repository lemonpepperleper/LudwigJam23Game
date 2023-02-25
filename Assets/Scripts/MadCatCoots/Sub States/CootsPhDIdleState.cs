using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsPhDIdleState : CootsPhDMovementState
{
    protected float lastHP;
    public CootsPhDIdleState(StateMachine stateMachine) : base("Idle", stateMachine)
    {
        
    }

    public override void OnEnter()
    {
        cootsSM.animator.Play("Idle");
        cootsSM.body.velocity = Vector2.zero;
        lastHP = cootsSM.hurtBox.currentHP;
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
        base.OnUpdate();
        if (distance < cootsSM.cootsData.swipeTriggerRange)
        {
            stateMachine.SwitchState(cootsSM.runState);
        }
    }
}
