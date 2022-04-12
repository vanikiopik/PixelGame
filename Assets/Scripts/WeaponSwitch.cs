using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    //ID = 0 - shotgun
    //ID = 1 - pistol 
    [SerializeField]
    private int _weaponID = 0;


    void Start()
    {
        //Seletcing the default weapon
        SelectWeapon();
    }


    void Update()
    {
        int currentWeapon = _weaponID;
        
        if (Input.mouseScrollDelta.y > 0f)
        {
            if (_weaponID >= transform.childCount - 1)
            {
                _weaponID = 0;
            }
            else
            {
            _weaponID++;
            }
        }

        else if (Input.mouseScrollDelta.y < 0f)
        {
            if(_weaponID <= 0)
            {
                _weaponID = transform.childCount - 1;
            }
            else
            {
            _weaponID--;
            }
        }

        if (currentWeapon != _weaponID)
        {
            SelectWeapon();
        }
    }


    void SelectWeapon()
    { 
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == _weaponID)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
