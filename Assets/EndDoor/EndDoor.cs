using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour
{
    public string nextlevelToLoad;
    public List<GameObject> collisions;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collisions.Add(collision.gameObject);
            if (collisions.Count == 2)
            {
                

                StartCoroutine(EndRoutine(3)); //3 is temp
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collisions.Remove(collision.gameObject);
        }
    }

    IEnumerator EndRoutine(float animationTime)
    {
        //Instantiate animated character obj
        //Play end animation here
        yield return new WaitForSeconds(animationTime + .5f);
        SceneManager.LoadScene(nextlevelToLoad);
    }
}
