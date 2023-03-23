using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    protected Rigidbody2D rb;
    
    static string[,] inputs = new string[2, 8]
    {
        {"P1_Horizontal", "P1_Vertical", "P1_Button1", "P1_Button2", "P1_Button3", "P1_Button4", "P1_Button5", "P1_Button6"},
        {"P2_Horizontal", "P2_Vertical", "P2_Button1", "P2_Button2", "P2_Button3", "P2_Button4", "P2_Button5", "P2_Button6"}
    };

    protected enum Buttons { Horizontal, Vertical, Button1, Button2, Button3, Button4, Button5, Button6};

    protected StateMachine machine;
    public Movement stateChecks;

    //I want to use the same script for both player 1 and 2. Set by 
    public int player;


    //There's an annoying amount of writing with this system for p1/p2 so these funcitons call the input functions correctly (I hope)
    protected bool ButtonDown(Buttons b)
    {
        return Input.GetButtonDown(inputs[player, (int)b]);
    }

    protected bool ButtonPressed(Buttons b)
    {
        return Input.GetButtonDown(inputs[player, (int)b]);
    }

    protected bool ButtonUp(Buttons b)
    {
        return Input.GetButtonUp(inputs[player, (int)b]);
    }


    protected float ButtonAxis(Buttons b)
    {
        return Input.GetAxis(inputs[player, (int)b]);
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    //Returns true if the input required to enter this state is checked.
    public virtual bool Check()
    {
        return false;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //called by stateMachine for movement code. Collects input in the base class.
    public virtual void machineUpdate()
    {

    }


    public void setMachine(StateMachine s)
    {
        machine = s;
        player = (int)s.Player;
    }
}
