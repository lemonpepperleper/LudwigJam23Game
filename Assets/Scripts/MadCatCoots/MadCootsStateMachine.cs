using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCootsStateMachine : StateMachine
{
    public MadCootsIdleState idleState;
    public MadCootsRunState runState;
    public MadCootsSwipeState swipeState;
    public MadCootsPunchState punchState;
    public MadCootsRoarState roarState;
    public MadCootsTornadoStartState tornadoStartState;
    public MadCootsTornadoEndState tornadoEndState;
    public MadCootsTornadoState tornadoState;
    public MadCootsStompState stompState;

    public Rigidbody2D body;
    public Animator animator;
    public CootsAbilityManager abilityManager;

    public Transform player;
    private bool isFlipped;

    public CootsData cootsData;

    private void Awake()
    {
        idleState = new MadCootsIdleState(this);
        runState = new MadCootsRunState(this);
        swipeState = new MadCootsSwipeState(this);
        punchState = new MadCootsPunchState(this);
        roarState = new MadCootsRoarState(this);
        tornadoState = new MadCootsTornadoState(this);
        tornadoStartState = new MadCootsTornadoStartState(this);
        tornadoEndState = new MadCootsTornadoEndState(this);
        stompState = new MadCootsStompState(this);
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
