using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carried : Movement
{
    public override bool Check ()
    {
        return base.Check ();
    }

    //Make this player a child of the other player.
    public override void Enter ()
    {
        base.Enter ();
    }

    public override void machineUpdate ()
    {


        base.machineUpdate ();
    }
}
