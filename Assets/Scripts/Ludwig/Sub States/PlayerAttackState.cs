using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private HitBox hitBox;

    public PlayerAttackState(PlayerStateMachine stateMachine) : base("Attack", stateMachine)
    {
        hitBox = playerSM.transform.Find("AttackHitBox").GetComponent<HitBox>();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        playerSM.animator.Play("Attack");
        playerSM.body.velocity = Vector2.zero;
    }

    public override void OnExit()
    {
        hitBox.ClearHitColliders();
    }

    public override void OnFixedUpdate()
    {

        if (hitBox.isActive)
        {
            hitBox.HitboxUpdate(playerData.atkDmg);
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (playerSM.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            abilityFinished = true;
        }
    }

}
