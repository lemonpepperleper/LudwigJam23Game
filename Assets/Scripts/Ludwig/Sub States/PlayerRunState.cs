using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerMovementState
{

    private bool isFlipped;

    public PlayerRunState(PlayerStateMachine stateMachine) : base("Run", stateMachine)
    {

    }

    public override void OnEnter()
    {
        playerSM.animator.Play("Run");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (direction.sqrMagnitude == 0)
        {
            stateMachine.SwitchState(playerSM.idleState);
        }
    }


    public override void OnFixedUpdate()
    {
        HandleFlip();
        playerSM.body.velocity = direction * playerData.moveSpeed;
    }


    public override void OnExit()
    {
        base.OnExit();
    }

    private void HandleFlip()
    {
        if (!isFlipped && direction.x < 0)
        {
            playerSM.transform.localScale = new Vector3(-1, 1, 1);
            isFlipped = true;
        }
        else if (isFlipped && direction.x > 0)
        {
            playerSM.transform.localScale = new Vector3(1, 1, 1);
            isFlipped = false;
        }
    }
}
