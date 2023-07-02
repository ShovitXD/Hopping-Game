using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform player; 
    public float smoothSpeed = 0.125f; 

    private Vector3 offset;

    void Start()
    {
       
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
       
        Vector3 targetPosition = new Vector3(transform.position.x, player.position.y + offset.y, player.position.z + offset.z);

        
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}


