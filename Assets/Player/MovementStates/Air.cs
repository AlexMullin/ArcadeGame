using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Movement
{
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] float driftSpeed = 3;
    [SerializeField] float driftChange = 1;

    public override bool Check()
    {
        return !Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundLayer);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void machineUpdate()
    {
        float inputX = ButtonAxis(Buttons.Horizontal);
        float velocityX = rb.velocity.x;

        velocityX = Mathf.MoveTowards(velocityX, inputX * driftSpeed, driftChange * Time.deltaTime);

        rb.velocity = new Vector2(velocityX, rb.velocity.y);


        base.machineUpdate ();
    }

    public override void fixedMachineUpdate()
    {
        base.fixedMachineUpdate();
    }

    public override bool checkCarry ()
    {
        return true;
    }
}
