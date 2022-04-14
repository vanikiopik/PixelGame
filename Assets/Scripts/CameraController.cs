using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public float smoothTime = 0.2f;
    private Vector2 _velocity = Vector2.zero;

    private void Start()
    {
        cam = GetComponent<Camera>();   
    }


    void FixedUpdate()
    {
        cam.nearClipPlane = -1;
        //Camera will move forward to the connected object
        if (target)
        {
            Vector2 pos = new Vector2(target.position.x, target.position.y);
            transform.position = Vector2.SmoothDamp(transform.position, target.position, ref _velocity, smoothTime);
        }
    }
}