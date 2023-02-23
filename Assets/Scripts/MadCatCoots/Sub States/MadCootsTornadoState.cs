using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsTornadoState : MadCootsAbilityState
{
    protected HitBox hitBox;

    protected Vector2 target;
    protected Vector2 newPos;

    public MadCootsTornadoState(StateMachine stateMachine) : base("Tornado", stateMachine)
    {
        hitBox = cootsSM.transform.Find("TornadoHitBox").GetComponent<HitBox>();
    }

    public override void OnEnter()
    {

        cootsSM.animator.Play("Tornado");

        abilityManager.isTornadoDone = false;
        abilityManager.isNextTornadoTickReady = true;

        abilityManager.StartCoroutine(abilityManager.TornadoNextTick());
        abilityManager.StartCoroutine(abilityManager.TornadoDuration());
    }

    public override void OnExit()
    {
        hitBox.ClearHitColliders();
    }

    public override void OnFixedUpdate()
    {
        cootsSM.FacePlayer(cootsSM.player);
        target = cootsSM.player.position;
        newPos = Vector2.MoveTowards(cootsSM.body.position, target, coots.tornadoSpeed * Time.fixedDeltaTime);
        cootsSM.body.MovePosition(newPos);

        if (hitBox.isActive && abilityManager.isNextTornadoTickReady)
        {

            abilityManager.isNextTornadoTickReady = false;
            hitBox.HitboxUpdate(coots.tornadoDmg);
            hitBox.ClearHitColliders();
            abilityManager.StartCoroutine(abilityManager.TornadoNextTick());
        }
    }

    public override void OnUpdate()
    {

        if (abilityManager.isTornadoDone)
        {
            stateMachine.SwitchState(cootsSM.tornadoEndState);
        }
    }
}
