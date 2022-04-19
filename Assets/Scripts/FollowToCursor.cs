using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowToCursor : MonoBehaviour
{
    public Transform spawnPos;  //Spawn point of bullets
    public GameObject target;  //Crosshair
    private PlayerMovement _parent;
    private SpriteRenderer _sprite;
    public Rigidbody2D bullet;


    private float _timeShoot;  
    [SerializeField]
    private float _shootCooldown; //KD between shoots


    void Start()
    {
       _parent =  GetComponentInParent<PlayerMovement>();
       _sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        //Gun will fillow to the crosshair
        Vector2 dir = (target.transform.position - transform.position);
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

        //Flip player's sprite 
        bool isLeft = dir.x < 0;
        _sprite.flipY = isLeft;
        _parent.FlipY(isLeft);


        //Shooting 
        if (_timeShoot <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(bullet, spawnPos.position, transform.rotation);
                _timeShoot = _shootCooldown;
            }
        }
        else
        {
            _timeShoot -= Time.deltaTime;  
        }
    }
}
