using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsSwipeState : MadCootsAbilityState
{
    protected HitBox hitBox;

    public MadCootsSwipeState(StateMachine stateMachine) : base("Swipe", stateMachine)
    {
        hitBox = cootsSM.transform.Find("SwipeHitBox").GetComponent<HitBox>();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        cootsSM.animator.Play("Swipe");
        cootsSM.body.velocity = Vector2.zero;
        abilityManager.isSwipeOffCd = false;
        abilityManager.StartCoroutine(abilityManager.SwipeCoolDown());
    }

    public override void OnExit()
    {
        hitBox.ClearHitColliders();
    }

    public override void OnFixedUpdate()
    {

        if (hitBox.isActive)
        {
            hitBox.HitboxUpdate(coots.swipeDmg);
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
