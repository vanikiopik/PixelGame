using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowToCursor : MonoBehaviour
{
    public GameObject target;
    private PlayerMovement parent;
    private SpriteRenderer sprite;

    void Start()
    {
       parent =  GetComponentInParent<PlayerMovement>();
       sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 dir = (target.transform.position - transform.position);
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

        bool isLeft = dir.x < 0;
        sprite.flipY = isLeft;
        parent.FlipY(isLeft);
    }
}
