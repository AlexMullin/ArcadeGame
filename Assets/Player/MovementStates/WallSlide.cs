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


    public float playerJumpBuffer = 0.25f;
    private bool playerTouching = false;
    private bool timerTrigger = true; //so we don't run the coroutine hundreds of times per

    //If the players begin touching, set player touching to true.
    //When this condition is no longer true, set playerTouching to no longer be true AFTER 0.5 seconds.

    void updateTouch ()
    {
        //if players are touching: 
        if (checkPoint(pointWallLeft, playerTarget) || checkPoint(pointWallRight, playerTarget))
        {
            playerTouching = true;
        }

        //If they have stopped touching: 
        else if (playerTouching && timerTrigger)
        {
            StartCoroutine (jumpBufferTimer (playerJumpBuffer));
        }
    }

    IEnumerator jumpBufferTimer (float t)
    {
        timerTrigger = false;
        yield return new WaitForSeconds (t);

        playerTouching = false;
        timerTrigger = true;
    }

    bool checkWall (Transform point)
    {

        return
            (checkPoint (point) ||
            checkPoint (point, playerTarget))
            
            ; 
        //Todo: Add a timer to add leniency to players jumping off each other
            ;
    }

    public override bool Check ()
    {
        return (
            (
                ((ButtonAxis (Buttons.Horizontal) < 0 && checkWall (pointWallLeft)) ||
                (ButtonAxis (Buttons.Horizontal) > 0 && checkWall (pointWallRight)) )

                || playerTouching == true //Accounts for the buffer between players walljumping
            )
            );
    }
    public override void Enter ()
    {
        base.Enter ();

    }
    public override void Exit ()
    {
        base.Exit ();
        playerTouching = false;
        timerTrigger = true;
    }

    public override void machineUpdate ()
    {
        updateTouch ();
        Vector2 direction = Vector2.zero;
        

        if (ButtonPressed (Buttons.Button5))
        {
            playerTouching = false;

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
