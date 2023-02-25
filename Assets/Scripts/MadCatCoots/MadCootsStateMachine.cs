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
    public MadCootsCrashState crashState;
    public MadCootsLeapChargeState leapChargeState;
    public MadCootsLandedState landedState;
    public MadCootsChargeState chargeState;
    public MadCootsDashChargeState dashChargeState;
    public MadCootsStunnedState stunnedState;

    public Rigidbody2D body;
    public Animator animator;
    public CootsAbilityManager abilityManager;
    public HurtBox hurtBox;

    public Transform player;
    public GlobalEvent global;

    public CootsData cootsData;

    private bool isFlipped;
    public bool enraged;
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
        crashState = new MadCootsCrashState(this);
        leapChargeState = new MadCootsLeapChargeState(this);
        landedState = new MadCootsLandedState(this);
        chargeState = new MadCootsChargeState(this);
        dashChargeState = new MadCootsDashChargeState(this);
        stunnedState = new MadCootsStunnedState(this);

    }


    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void FacePlayer(Transform player)
    {

        if (transform.position.x >= player.position.x && isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
