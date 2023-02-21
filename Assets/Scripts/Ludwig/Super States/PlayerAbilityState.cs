using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : BaseState
{
    protected PlayerStateMachine playerSM;
    protected PlayerAbilityManager abilityManager;
    protected PlayerData playerData;

    protected bool abilityFinished;

    public PlayerAbilityState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        playerSM = (PlayerStateMachine)stateMachine;
        abilityManager = playerSM.abilityManager;
        playerData = playerSM.playerData;
    }

    public override void OnEnter()
    {
        abilityFinished = false;
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnUpdate()
    {
        if (abilityFinished)
        {
            playerSM.SwitchState(playerSM.idleState);
        }
    }

}
