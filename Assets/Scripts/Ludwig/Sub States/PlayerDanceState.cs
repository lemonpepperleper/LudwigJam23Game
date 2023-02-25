using UnityEngine;
using System.Collections;

public class PlayerDanceState : PlayerAbilityState
{

    protected Vector2 direction;

    public PlayerDanceState(StateMachine stateMachine) : base("Luddy", stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        playerSM.animator.Play("Luddy");
        playerSM.body.velocity = Vector2.zero;
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {

        abilityManager.RefillManaBar();
        abilityManager.RefillHpBar();
    }

    public override void OnUpdate()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        base.OnUpdate();
        if (Input.GetKeyDown(KeyCode.C) || direction.sqrMagnitude != 0)
        {
            abilityFinished = true;
        }
    }
}
