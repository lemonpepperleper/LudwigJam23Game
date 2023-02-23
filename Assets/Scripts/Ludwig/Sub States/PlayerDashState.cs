using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    private float currentDashTime;
    protected Vector2 lastmove;

    public PlayerDashState(StateMachine stateMachine) : base("Dash", stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        playerSM.animator.Play("Run");
        abilityManager.isDashOffCd = false;
        currentDashTime = playerData.dashTime;
        abilityManager.SpendMana(playerData.dashManaCost);
        abilityManager.StartCoroutine(abilityManager.DashCooldown());
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
        if (currentDashTime <= 0)
        {
            //PlayerCombat.invincible = false;
            currentDashTime = playerData.dashTime;
            abilityFinished = true;
        }
        else
        {
            currentDashTime -= Time.deltaTime;
            playerSM.body.velocity += playerSM.lastMove * playerData.dashSpeed;
            //PlayerCombat.invincible = true;
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

}
