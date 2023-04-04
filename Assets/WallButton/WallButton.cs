using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    public GameObject myWallToEnable;
    private void Start()
    {
        myWallToEnable.GetComponent<BoxCollider2D>().enabled = false;
        myWallToEnable.GetComponent<SpriteRenderer>().color = new Color(0, 255, 236, .3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            myWallToEnable.GetComponent<BoxCollider2D>().enabled = true;
            myWallToEnable.GetComponent<SpriteRenderer>().color = new Color(0, 255, 236, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            myWallToEnable.GetComponent<BoxCollider2D>().enabled = false;
            myWallToEnable.GetComponent<SpriteRenderer>().color = new Color(0, 255, 236, .3f);
        }
    }
}
