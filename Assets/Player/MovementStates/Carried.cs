using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carried : Movement
{
    public Vector2 throwPower = Vector2.zero;

    public Transform catchPoint;

    public override bool Check ()
    {
        return checkPoint (catchPoint, playerTarget);
    }

    //Make this player a child of the other player.
    public override void Enter ()
    {
        transform.parent = GameObject.Find (playerTarget).transform;
        transform.localPosition = new Vector2 (0, 1);
        
        base.Enter ();
    }

    public override void machineUpdate ()
    {


        base.machineUpdate ();
    }

    public void throwPlayer (bool facingRight)
    {
        transform.SetParent (null);

        if (facingRight)
        {
            rb.velocity = throwPower;
        }
        else
        {
            Vector2 newThrow = throwPower;
            newThrow.x *= -1;

            rb.velocity = newThrow;
        }
    }
}
