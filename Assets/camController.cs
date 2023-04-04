using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour
{
    public GameObject playerA;
    public GameObject playerB;
    

    void Update()
    {
        Vector2 midPoint = (playerB.transform.position - playerA.transform.position) / 2;
        transform.position = new Vector3(midPoint.x, midPoint.y + 5, -10);
    }
}
