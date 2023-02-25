using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsChargeState : MadCootsAbilityState
{
    protected HitBox hitBox;

    protected Vector2 direction;
    protected Vector2 target;
    private float num;
    private Vector2 lastPos;
    private float timer;
    private float threshold;

    public MadCootsChargeState(StateMachine stateMachine) : base("Charge", stateMachine)
    {
        hitBox = cootsSM.transform.Find("ChargeHitBox").GetComponent<HitBox>();
    }

    public override void OnEnter()
    {
        lastPos = cootsSM.body.position;
        timer = Time.time;

        target = cootsSM.player.position;
        num = cootsSM.global.numOfBoulders;
        cootsSM.animator.Play("Dash");
        cootsSM.body.velocity = Vector2.zero;
    }

    public override void OnExit()
    {
        hitBox.ClearHitColliders();
    }

    public override void OnFixedUpdate()
    {

        if (hitBox.isActive)
        {
            Vector2 newPos = Vector2.MoveTowards(cootsSM.body.position, target, coots.chargeSpeed * Time.fixedDeltaTime);
            cootsSM.body.MovePosition(newPos);

            hitBox.HitboxUpdate(coots.chargeDmg);
        } 
    }

    public override void OnUpdate()
    {
        if (cootsSM.global.numOfBoulders <= 0)
        {
            stateMachine.SwitchState(cootsSM.idleState);
        }

        if (cootsSM.global.numOfBoulders < num)
        {
            stateMachine.SwitchState(cootsSM.stunnedState);
        }

        if (cootsSM.body.position == target || Time.time - timer > 0.1f)
        {
            stateMachine.SwitchState(cootsSM.dashChargeState);
        }


        if (cootsSM.body.position != lastPos)
        {
            lastPos = cootsSM.body.position;
            timer = Time.time;
        }

    }
}
