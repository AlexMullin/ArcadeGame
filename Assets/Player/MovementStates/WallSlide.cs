using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : Movement
{
    [SerializeField] private Transform pointGround;
    [SerializeField] private Transform pointWallLeft;
    [SerializeField] private Transform pointWallRight;

    [SerializeField] private WallCling clingCheck;

    [SerializeField] private LayerMask groundLayer, playerLayer;

    //How hard up are you pushing the player while sliding?
    [SerializeField] private float slideSpeed = 1f;
    [SerializeField] private float wallJumpX = 1;
    [SerializeField] private float wallJumpY = 1;

    bool checkWall (Transform point)
    {
        return 
            Physics2D.OverlapCircle (point.position, 0.02f, groundLayer) != null ||
            Physics2D.OverlapCircle (point.position, 0.02f, playerLayer) != null
            ;
    }

    public override bool Check ()
    {
        return (
            (
                (ButtonAxis (Buttons.Horizontal) < 0 && checkWall (pointWallLeft)) ||
                (ButtonAxis (Buttons.Horizontal) > 0 && checkWall (pointWallRight)) 
            )
            );
    }
    public override void Enter ()
    {
        base.Enter ();
    }

    public override void machineUpdate ()
    {
        Vector2 direction = Vector2.zero;
        

        if (ButtonPressed (Buttons.Button5))
        {

            direction.x = -ButtonAxis (Buttons.Horizontal) * wallJumpX;
            direction.y = wallJumpY;

            rb.velocity = direction;
        }

        if (clingCheck.Check ())
        {
            machine.transitionState (clingCheck);
            Debug.Log (clingCheck);
        }

        //Wallslide has priority over the other states, so only look for other 
        if (!Check ())
        {
            checkStates ();
        }
    }
}
