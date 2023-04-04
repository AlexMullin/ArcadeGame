using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    Camera cam;
    public GameObject player1, player2;


    [SerializeField] float 
        minSize = 5, 
        minSizeDistance = 10;

    private void Start ()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 position = (player1.transform.position + player2.transform.position) / 2;
        position.z --;

        float testSize = (player1.transform.position - player2.transform.position).magnitude / 2;
        Debug.Log (testSize);

        cam.orthographicSize = testSize > 5 ? testSize : 5;

        transform.position = position;
    }
}
