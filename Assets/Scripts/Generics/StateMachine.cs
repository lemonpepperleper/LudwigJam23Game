using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{

    BaseState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.OnEnter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.OnFixedUpdate();
        }
    }

    public void SwitchState(BaseState newState)
    {
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }

    protected abstract BaseState GetInitialState();


    private void OnGUI()
    {
        string tooltip = currentState != null ? currentState.name : "no state";
        GUILayout.Label($"<color='black'><size=40>{tooltip}</size></color>");
    }
}
