using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private const float followSpeed = 7f;
    private const float yPosition = 0.1f;  
    private Transform player; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetPosition = player.position; 
        Vector2 smoothPosition = Vector2.Lerp(transform.position, player.position, followSpeed * Time.deltaTime); 
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y + yPosition, -15f); 
    }
}
