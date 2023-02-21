

public abstract class BaseState
{
    public string name;
    public StateMachine stateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }

    public abstract void OnEnter();

    public abstract void OnUpdate();

    public abstract void OnFixedUpdate();

    public abstract void OnExit();

}