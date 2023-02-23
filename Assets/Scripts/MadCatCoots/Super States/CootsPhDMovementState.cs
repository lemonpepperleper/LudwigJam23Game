using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsPhDMovementState : BaseState
{
    protected CootsPhDStateMachine cootsSM;
    protected CootsAbilityManager abilityManager;
    protected CootsData coots;
    protected HurtBox hurtBox;

    protected float distance;


    public CootsPhDMovementState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        cootsSM = (CootsPhDStateMachine)stateMachine;
        abilityManager = cootsSM.abilityManager;
        coots = cootsSM.cootsData;
        hurtBox = cootsSM.hurtBox;
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
        cootsSM.FacePlayer(cootsSM.player);
    }

    public override void OnUpdate()
    {
        distance = Vector2.Distance(cootsSM.player.position, cootsSM.body.position);

        if (hurtBox.currentHP <= 0)
        {

        }

    }
}
