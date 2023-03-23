using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum playerSelect { Player1, Player2 };

    public playerSelect Player = playerSelect.Player1;


    public Movement[] States;
    Movement currentState;

    public void transitionState(Movement newState)
    {
        currentState.Exit();

        currentState = newState;

        currentState.Enter();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Movement state in States)
        {
            state.setMachine(this);
        }

        currentState = States[0];
    }

    // Update is called once per frame
    void Update()
    {
        currentState.machineUpdate();
    }
}
