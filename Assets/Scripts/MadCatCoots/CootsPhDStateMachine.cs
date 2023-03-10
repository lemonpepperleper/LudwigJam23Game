using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsPhDStateMachine : StateMachine
{
    public CootsPhDIdleState idleState;
    public CootsPhDRunState runState;
    public CootsPhDThrowState throwState;
    public CootsPhDTransitionState transitionState;

    public Rigidbody2D body;
    public Animator animator;
    public CootsAbilityManager abilityManager;
    public HurtBox hurtBox;

    public Transform player;
    public GameObject bottlePrefab;
    public GlobalEvent global;

    public CootsData cootsData;

    private void Awake()
    {
        idleState = new CootsPhDIdleState(this);
        runState = new CootsPhDRunState(this);
        throwState = new CootsPhDThrowState(this);
        transitionState = new CootsPhDTransitionState(this);
    }


    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void FacePlayer(Transform player)
    {
        if (transform.position.x >= player.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
