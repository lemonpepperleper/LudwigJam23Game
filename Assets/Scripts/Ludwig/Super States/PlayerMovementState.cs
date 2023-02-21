using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : BaseState
{
    protected PlayerStateMachine playerSM;
    protected PlayerAbilityManager abilityManager;
    protected PlayerData playerData;

    protected Vector2 direction;

    public PlayerMovementState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        playerSM = (PlayerStateMachine)stateMachine;
        abilityManager = playerSM.abilityManager;
        playerData = playerSM.playerData;
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {
        if (direction.sqrMagnitude > 0)
        {
            playerSM.lastMove = direction;
        }
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.SwitchState(playerSM.attackState);
        }

        if (Input.GetKeyDown(KeyCode.Space) && abilityManager.isDashOffCd && abilityManager.currentMana > playerData.dashManaCost)
        {
            stateMachine.SwitchState(playerSM.dashState);
        }
    }

}
