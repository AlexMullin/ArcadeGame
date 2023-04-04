using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry_Air : Movement
{
    [SerializeField] Transform groundPoint;

    [SerializeField] float driftSpeed = 3;
    [SerializeField] float driftChange = 1;

    Air movementAir;

    bool throwRight = true;


    protected override void Start ()
    {
        movementAir = GetComponent<Air>();

        base.Start ();
    }
    public override void Enter ()
    {
        base.Enter ();
    }
    public override void Exit ()
    {
        base.Exit ();
    }

    public override bool Check ()
    {
        return !checkPoint (groundPoint, "Ground");
    }

    public override void returnFromThrow ()
    {
        machine.transitionState (movementAir);
    }

    public override void machineUpdate ()
    {
        float inputX = ButtonAxis (Buttons.Horizontal);
        float velocityX = rb.velocity.x;

        if (inputX > 0) throwRight = true;
        else if (inputX < 0) throwRight = false;

        velocityX = Mathf.MoveTowards (velocityX, inputX * driftSpeed, driftChange * Time.deltaTime);

        rb.velocity = new Vector2 (velocityX, rb.velocity.y);

        if (ButtonDown (Buttons.Button4))
        {
            otherPlayer.GetComponent<Carried> ().throwPlayer (throwRight);
        }

        base.machineUpdate ();
    }
}
