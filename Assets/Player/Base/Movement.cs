using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    static string[,] inputs = new string[2, 8]
    {
        {"P1_Horizontal", "P1_Vertical", "P1_Button1", "P1_Button2", "P1_Button3", "P1_Button4", "P1_Button 5", "P1_Button 6"},
        {"P2_Horizontal", "P2_Vertical", "P2_Button1", "P2_Button2", "P2_Button3", "P2_Button4", "P2_Button 5", "P2_Button 6"}
    };

    enum gameInput { Horizontal, Vertical, Button1, Button2, Button3, Button4, Button5, Button6};

    public StateMachine machine;
    public Movement stateChecks;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
