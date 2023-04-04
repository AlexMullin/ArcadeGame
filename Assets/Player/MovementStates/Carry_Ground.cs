using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry_Ground : Movement
{
    [SerializeField] Transform groundPoint;

    Grounded movementGround;
    public float jumpMod = 1;

    bool throwRight = true;

    protected override void Start ()
    {
        base.Start ();

        movementGround = GetComponent<Grounded> ();
    }
    public override void Enter ()
    {
        
        base.Enter ();
    }
    public override bool Check ()
    {
        return checkPoint (groundPoint, "Ground");
    }

    public override void returnFromThrow ()
    {
        machine.transitionState (movementGround);
    }

    public override void machineUpdate ()
    {
        if (ButtonDown (Buttons.Button5))
        {
            rb.AddForce (Vector3.up * jumpHeight * jumpMod, ForceMode2D.Impulse);

        }

        float inputX = ButtonAxis (Buttons.Horizontal);
        rb.velocity = new Vector2 (inputX * walkSpeed, rb.velocity.y);

        if (inputX > 0) throwRight = true;
        else if (inputX < 0) throwRight = false;

        if (ButtonDown (Buttons.Button4))
        {
            otherPlayer.GetComponent<Carried> ().throwPlayer (throwRight);
        }

        base.machineUpdate ();
    }
}
