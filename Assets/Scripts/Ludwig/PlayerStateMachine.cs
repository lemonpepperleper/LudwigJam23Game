
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    public PlayerIdleState idleState;
    public PlayerRunState runState;
    public PlayerAttackState attackState;
    public PlayerDashState dashState;
    public PlayerDanceState danceState;

    public Rigidbody2D body;
    public Animator animator;
    public PlayerAbilityManager abilityManager;
    public HurtBox hurtBox;

    //public ResourceBar manaBar;
    //private float currentMana;

    public PlayerData playerData;

    public Vector2 lastMove;

    private void Awake()
    {
        idleState = new PlayerIdleState(this);
        runState = new PlayerRunState(this);
        attackState = new PlayerAttackState(this);
        dashState = new PlayerDashState(this);
        danceState = new PlayerDanceState(this);

    }


    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
