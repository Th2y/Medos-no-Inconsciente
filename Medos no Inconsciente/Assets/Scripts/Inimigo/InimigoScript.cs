using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoScript : MonoBehaviour
{
    private InimigoAbstrato currentState;
    public float speed = 2.5f;
    public Transform player;

    public InimigoAbstrato CurrentState
    {
        get { return currentState; }
    }

    public readonly ModoAtacar FollowState = new ModoAtacar();
    public readonly ModoPatrulha PatrolState = new ModoPatrulha();

    void Start()
    {
        TransitionToState(PatrolState);
    }

    void Update()
    {
        currentState.Update(this);
    }

    public void TransitionToState(InimigoAbstrato state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
