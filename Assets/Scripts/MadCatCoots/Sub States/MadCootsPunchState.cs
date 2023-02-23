using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsPunchState : MadCootsAbilityState
{
    protected HitBox hitBox;

    protected Vector2 direction;
    protected Vector2 target;

    public MadCootsPunchState(StateMachine stateMachine) : base("Punch", stateMachine)
    {
        hitBox = cootsSM.transform.Find("PunchHitBox").GetComponent<HitBox>();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        target = cootsSM.player.position;

        cootsSM.animator.Play("Punch");
        cootsSM.body.velocity = Vector2.zero;
        abilityManager.isPunchOffCd = false;
        abilityManager.StartCoroutine(abilityManager.PunchCoolDown());
    }

    public override void OnExit()
    {
        hitBox.ClearHitColliders();
    }

    public override void OnFixedUpdate()
    {

        if (hitBox.isActive)
        {
            Vector2 newPos = Vector2.MoveTowards(cootsSM.body.position, target, coots.punchDashSpeed * Time.fixedDeltaTime);
            cootsSM.body.MovePosition(newPos);

            hitBox.HitboxUpdate(coots.punchDmg);
        } else
        {
            target = cootsSM.player.position;
            cootsSM.FacePlayer(cootsSM.player);
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (cootsSM.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            abilityFinished = true;
        }
    }
}
