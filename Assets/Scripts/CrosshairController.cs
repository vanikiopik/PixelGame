using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        //Hide the cursor
        Cursor.visible = false;
        
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Get the vector to calculate pos between mouse & player
        Vector2 playToCros = (gameObject.transform.position - player.transform.position).normalized;


        //Make that feature for attacking event !!!

        /*if (playToCros.x < 0f)
        {
            player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if(playToCros.x > 0f)
        {
            player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }*/
    }
}
