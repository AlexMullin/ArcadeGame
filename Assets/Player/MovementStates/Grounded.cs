using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : Movement
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void machineUpdate()
    {
        base.machineUpdate();
        if (ButtonUp(Buttons.Button6))
        {
            rb.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
        }
    }
}
