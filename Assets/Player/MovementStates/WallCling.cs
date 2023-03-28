using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCling : Movement
{
    [SerializeField] private Transform cornerLeft, cornerRight, cornerLeftB, cornerRightB;
    [SerializeField] private float jumpHeight = 5;

    [SerializeField] float timer;
    private bool grabEnabled = true;


    // Start is called before the first frame update
    public override bool Check ()
    {
        return
            ((checkPoint (cornerLeft) && !checkPoint (cornerLeftB) && ButtonAxis (Buttons.Horizontal) < 0) ||
            (checkPoint (cornerRight) && !checkPoint (cornerRightB) && ButtonAxis (Buttons.Horizontal) > 0)) &&
            (!ButtonDown (Buttons.Button5)) &&
            grabEnabled == true;
            ;

    }

    public override void Enter ()
    {
        base.Enter ();

        gameObject.transform.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
    }
    public override void Exit ()
    {
        
        StartCoroutine (refreshTimer (timer));

        base.Exit ();
        gameObject.transform.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
    }

    public override void machineUpdate ()
    {

        if (ButtonDown (Buttons.Button5))
        {
            gameObject.transform.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

            Vector2 direction = Vector2.up * jumpHeight;

            rb.AddForce (direction, ForceMode2D.Impulse);
        }

        if (!Check ())
        {
            checkStates ();
        }
    }

    
    IEnumerator refreshTimer (float t)
    {
        grabEnabled = false;
        yield return new WaitForSeconds (t);
        grabEnabled = true;
    }
}
