using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera cam;
    private Rigidbody2D rb;
    public LayerMask layerMaskToIgnore;
    private bool isGrappleing;

    public float maxDist;
    public float minDist;
    public bool postGrappleBounce;
    public float bounceForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShootGrapple()
    {
        Vector3 mOuSe = new(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mOuSe);
        
        //if can grapple
        StartCoroutine(GrappleRoutine(worldPosition, .17f));
        //end if
    }

    public IEnumerator GrappleRoutine(Vector2 targetPos, float duration)
    {
        LineRenderer line = GetComponent<LineRenderer>();

        Vector2 dir = targetPos - new Vector2(transform.position.x, transform.position.y);
        Vector2 finalTargetPos;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, maxDist, ~layerMaskToIgnore);
        if (hit && hit.distance > minDist)
        {
            isGrappleing = true;

            //take away controll from the players
            //canMove = false; 

            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);

            Debug.DrawLine(transform.position, hit.point, Color.white, 1);
            
            //auidioSource.clip = clips[1];
            //auidioSource.Play();

            if (hit.point.y > transform.position.y)//Prevents clipping through ground or ceiling
            {
                finalTargetPos.y = hit.point.y - .5f;
            }
            else
            {
                finalTargetPos.y = hit.point.y + .5f; 
            }

            if (hit.point.x > transform.position.x)//Prevents clipping through walls
            {
                finalTargetPos.x = hit.point.x - .5f;
            }
            else
            {
                finalTargetPos.x = hit.point.x + .5f;
            }

            for (float t = 0f; t < duration; t += Time.deltaTime)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(finalTargetPos.x, finalTargetPos.y), t / duration);
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                isGrappleing = true;
                yield return 0;
                if (postGrappleBounce)
                {
                    rb.velocity = new Vector2(rb.velocity.x, bounceForce); //adds a little bounce after grappleing
                }
            }

            isGrappleing = false;

            //give controll back to the player
            //canMove = true;

            rb.gravityScale = 10;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position);
        }
        else
        {
            //canMove = true;
            rb.gravityScale = 10;
        }

    }

}
