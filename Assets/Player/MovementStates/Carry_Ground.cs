using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry_Ground : Movement
{
    public override bool Check ()
    {
        return base.Check ();
    }

    public override bool checkCarry ()
    {
        return base.checkCarry ();
    }

    public override void machineUpdate ()
    {
        if (ButtonDown (Buttons.Button5))
        {
            rb.AddForce (Vector3.up * jumpHeight, ForceMode2D.Impulse);
        }

        base.machineUpdate ();
    }
}
