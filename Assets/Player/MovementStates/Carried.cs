using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carried : Movement
{
    public Vector2 throwPower = Vector2.zero;

    public Transform catchPoint;

    public float regrabTime = 2;

    Air movementAir;

    bool canBeGrabbed = true;

    protected override void Start ()
    {
        otherPlayer = GameObject.Find (playerTarget);
        movementAir = GetComponent<Air>();
        base.Start ();
    }

    public override bool Check ()
    {
        return
            checkPoint (catchPoint, playerTarget)
            && canBeGrabbed
            && otherPlayer.GetComponent<StateMachine> ().currentState.checkCarry ();
    }

    //Make this player a child of the other player.
    public override void Enter ()
    {
        
        transform.parent = otherPlayer.transform;

        transform.localPosition = new Vector2 (0, 1);

        otherPlayer.GetComponent<StateMachine> ().currentState.beginCarry ();

        base.Enter ();
    }

    public override void Exit ()
    {
        transform.parent = null;

        otherPlayer.GetComponent<StateMachine> ().currentState.returnFromThrow ();

        StartCoroutine (regrabTimer (regrabTime));

        base.Exit ();
    }

    public override void machineUpdate ()
    {
        transform.position = otherPlayer.transform.position + new Vector3 (0, 1.01f, 0);

        if (ButtonDown (Buttons.Button5))
        {
            machine.transitionState (movementAir);
            rb.AddForce (Vector3.up * jumpHeight, ForceMode2D.Impulse);
        }

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

        machine.transitionState (movementAir);
    }

    IEnumerator regrabTimer (float t)
    {
        canBeGrabbed = false;

        yield return new WaitForSeconds (t);

        canBeGrabbed = true;
    }
}
