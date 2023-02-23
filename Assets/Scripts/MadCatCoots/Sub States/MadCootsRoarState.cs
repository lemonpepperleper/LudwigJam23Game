using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsRoarState : MadCootsAbilityState
{

    protected HitBox hitBox;

    public MadCootsRoarState(StateMachine stateMachine) : base("Roar", stateMachine)
    {
        hitBox = cootsSM.transform.Find("RoarHitBox").GetComponent<HitBox>();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        cootsSM.animator.Play("Roar");
        cootsSM.body.velocity = Vector2.zero;

        abilityManager.isRoarOffCd = false;
        abilityManager.isRoarDone = false;
        abilityManager.isNextRoarTickReady = true;

        abilityManager.StartCoroutine(abilityManager.RoarCoolDown());
        abilityManager.StartCoroutine(abilityManager.RoarDuration());
    }

    public override void OnExit()
    {
        hitBox.ClearHitColliders();
    }

    public override void OnFixedUpdate()
    {

        if (hitBox.isActive && abilityManager.isNextRoarTickReady)
        {
            abilityManager.isNextRoarTickReady = false;
            hitBox.HitboxUpdate(coots.roarDmg);
            hitBox.ClearHitColliders();
            abilityManager.StartCoroutine(abilityManager.RoarNextTick());
        } 
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (abilityManager.isRoarDone)
        {
            abilityFinished = true;
        }
    }
}
