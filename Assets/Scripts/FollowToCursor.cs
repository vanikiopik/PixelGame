using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowToCursor : MonoBehaviour
{
    public Transform spawnPos;  //Spawn point of bullets
    public GameObject target;  //Crosshair
    private PlayerMovement parent;
    private SpriteRenderer sprite;
    public Rigidbody2D bullet;


    private float timeShoot;  
    [SerializeField]
    private float shootCooldown; //KD between shoots


    void Start()
    {
       parent =  GetComponentInParent<PlayerMovement>();
       sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        //Gun will fillow to the crosshair
        Vector2 dir = (target.transform.position - transform.position);
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

        //Flip player's sprite 
        bool isLeft = dir.x < 0;
        sprite.flipY = isLeft;
        parent.FlipY(isLeft);

        //Shooting 
        if (timeShoot <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(bullet, spawnPos.position, transform.rotation);
                timeShoot = shootCooldown;
            }
        }
        else
        {
            timeShoot -= Time.deltaTime;  
        }
    }
}
