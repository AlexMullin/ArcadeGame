using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //Player Selection Releated
    public enum playerSelect { Player1, Player2 };

    public playerSelect Player = playerSelect.Player1;

    //Movement staes related
    public Movement[] States;
    Movement currentState;


    // Start is called before the first frame update
    private void Start()
    {

        foreach (Movement state in States)
        {
            state.setMachine(this);
        }

        currentState = States[0];
        transitionState(States[0]);

        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.machineUpdate();

        if (Input.GetButtonDown ("Game_Escape"))
        {
            Application.Quit ();
        }
    }


    private void FixedUpdate()
    {
        currentState.fixedMachineUpdate();
    }


    public void transitionState(Movement newState)
    {
        currentState.Exit();

        currentState = newState;

        currentState.Enter();
    }
}
