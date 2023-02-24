using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsPhDThrowState : BaseState
{
    protected CootsPhDStateMachine cootsSM;
    protected Transform throwPoint;

    public CootsPhDThrowState(StateMachine stateMachine) : base("Throw", stateMachine)
    {
        cootsSM = (CootsPhDStateMachine)stateMachine;
        throwPoint = cootsSM.transform.Find("ThrowPoint");
    }

    public override void OnEnter()
    {
        cootsSM.animator.Play("Throw");
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
        if (cootsSM.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Object.Instantiate(cootsSM.bottlePrefab, throwPoint.position, Quaternion.identity);
            stateMachine.SwitchState(cootsSM.idleState);
        }
    }
}
