using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : Movement
{


    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask groundLayer;

    public override bool Check()
    {
        return Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundLayer);
    }

    // Update is called once per frame
    public override void machineUpdate()
    {
        if (ButtonDown(Buttons.Button5))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
        }

        float inputX = ButtonAxis(Buttons.Horizontal);
        rb.velocity = new Vector2(inputX * walkSpeed, rb.velocity.y);


        base.machineUpdate ();
    }


    public override bool checkCarry ()
    {
        return true;
    }
}
