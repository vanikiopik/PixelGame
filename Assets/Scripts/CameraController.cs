using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    private Vector2 velocity = Vector2.zero;
    
    void FixedUpdate()
    {
        //Camera will move forward to the connected object
        if (target)
        {
            Vector2 pos = new Vector2(target.position.x, target.position.y);
            transform.position = Vector2.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        }
    }
}
