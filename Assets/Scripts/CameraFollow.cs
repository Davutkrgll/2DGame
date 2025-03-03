using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraSpeed = 2f;
    public Transform target;

    
    void Update()
    {
        Vector3 newPosition =new Vector3(target.position.x, target.position.y, -10f);
        transform.position =  Vector3.Slerp(transform.position,newPosition, cameraSpeed * Time.deltaTime);
    }
}
