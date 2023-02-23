using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsPhDStateMachine : StateMachine
{
    public CootsPhDIdleState idleState;
    public CootsPhDRunState runState;

    public Rigidbody2D body;
    public Animator animator;
    public CootsAbilityManager abilityManager;
    public HurtBox hurtBox;

    public Transform player;
    private bool isFlipped;

    public CootsData cootsData;

    private void Awake()
    {
        idleState = new CootsPhDIdleState(this);
        runState = new CootsPhDRunState(this);
    }


    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void FacePlayer(Transform player)
    {

        if (transform.position.x >= player.position.x && isFlipped)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFlipped = true;
        }
    }
}
